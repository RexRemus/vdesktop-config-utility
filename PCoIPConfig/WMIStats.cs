using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace PCoIPConfig
{
    public class WMIStats
    {
        double timerInterval;

        // WMI Queries
        ObjectQuery generalQuery = new ObjectQuery("SELECT BytesReceived, BytesSent, PacketsReceived, PacketsSent, SessionDurationSeconds, TXPacketsLost, RXPacketsLost FROM Win32_PerfRawData_TeradiciPerf_PCoIPSessionGeneralStatistics");
        ObjectQuery imageQuery = new ObjectQuery("SELECT ImagingActiveMinimumQuality, ImagingBytesReceived, ImagingBytesSent, ImagingDecoderCapabilitykbitPersec, ImagingEncodedFramesPersec, ImagingRXBWkbitPersec, ImagingTXBWkbitPersec FROM Win32_PerfRawData_TeradiciPerf_PCoIPSessionImagingStatistics");
        ObjectQuery networkQuery = new ObjectQuery("SELECT RoundTripLatencyms,RXBWkbitPersec,RXBWPeakkbitPersec,TXBWActiveLimitkbitPersec, TXBWkbitPersec, TXBWLimitkbitPersec FROM Win32_PerfRawData_TeradiciPerf_PCoIPSessionNetworkStatistics");
        ObjectQuery audioQuery = new ObjectQuery("SELECT AudioBytesReceived, AudioBytesSent, AudioRXBWkbitPersec, AudioTXBWkbitPersec, AudioTXBWLimitkbitPersec FROM Win32_PerfRawData_TeradiciPerf_PCoIPSessionAudioStatistics");
        ObjectQuery pcoipCPUQuery = new ObjectQuery("SELECT PercentProcessorTime,TimeStamp_Sys100NS FROM Win32_PerfRawData_PerfProc_Process where Name = 'pcoip_server_win32'");

        // WMI Values for data calculation
        ulong prevPCoIPCPUUtil;
        ulong prevPCoIPCPUTime;
        double pcoipCPUUtilPeak;
        ulong prevTxPktLoss;
        ulong prevTxPktSent;
        double txPktLossPeak;
        ulong prevImgTxBW;
        double imgTxBWPeak;
        ulong prevAudTxBW;
        double audTxBWPeak;
        double prevTotalTxBW;
        double totalTxBWPeak;
        double imgFPSPeak;
        double netLatencyPeak;

        //WMI final values
        private string sessionDuration;
        private double totalTxBW;
        private double activeTxBWLimit;
        private double txPktLoss;
        private double pcoipCPUUtil;
        private double imageTxBW;
        private double imgFPS;
        private double netLatency;
        private double audioTxBW;

        public WMIStats(double timerInterval)
        {
            this.timerInterval = timerInterval;
        }

        public double getAudioTxBW()
        {
            return audioTxBW;
        }

        public double getAudioTxBWPeak()
        {
            return audTxBWPeak;
        }

        public double getImageTxBW()
        {
            return imageTxBW;
        }

        public double getImageTxBWPeak()
        {
            return imgTxBWPeak;
        }

        public double getActiveTxBWLimit()
        {
            return activeTxBWLimit;
        }

        public string getSessionDuration()
        {
            return sessionDuration;
        }

        public double getTotalTxBW() {
            return totalTxBW;
        }

        public double getTotalTxBWPeak()
        {
            return totalTxBWPeak;
        }

        public double getTxPktLoss()
        {
            return txPktLoss;
        }

        public double getTxPktLossPeak()
        {
            return txPktLossPeak;
        }

        public double getPCoIPCPUUtil()
        {
            return pcoipCPUUtil;
        }

        public double getPCoIPCPUUtilPeak()
        {
            return pcoipCPUUtilPeak;
        }

        public double getImageFPS()
        {
            return imgFPS;
        }

        public double getImageFPSPeak()
        {
            return imgFPSPeak;
        }

        public double getNetLatency()
        {
            return netLatency;
        }

        public double getNetLatencyPeak()
        {
            return netLatencyPeak;
        }

        public void collectWMIStats()
        {
            // General Session Stats
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT BytesReceived, BytesSent, PacketsReceived, PacketsSent, SessionDurationSeconds, TXPacketsLost, RXPacketsLost FROM Win32_PerfRawData_TeradiciPerf_PCoIPSessionGeneralStatistics");

            // Total session duration
            foreach (ManagementObject obj in searcher.Get())
            {
                ulong sessionDurationSec = Convert.ToUInt64(obj["SessionDurationSeconds"]);
                // Get elapsed time in seconds
                int elapsedTimeSec = ((int)sessionDurationSec) % 60;
                // Get elapsed time in minutes
                int elapsedTimeMin = ((int)(sessionDurationSec / 60)) % 60;
                // Get elapsed time in hours
                int elapsedTimeHour = ((int)(sessionDurationSec / (60 * 60))) % 24;
                // Get elapsed time in days
                int elapsedTimeDay = (int)(sessionDurationSec / (24 * 60 * 60));
                sessionDuration = string.Format("{0:00}d:{1:00}h:{2:00}m:{3:00}s", elapsedTimeDay, elapsedTimeHour, elapsedTimeMin, elapsedTimeSec);

                // Total bandwidth
                if (prevTotalTxBW != 0)
                {
                    totalTxBW = ((Convert.ToUInt64(obj["BytesSent"]) - prevTotalTxBW) * 8) / 1024.0 / (timerInterval / 1000);
                    if (totalTxBW > totalTxBWPeak) totalTxBWPeak = totalTxBW;
                }
                prevTotalTxBW = Convert.ToUInt64(obj["BytesSent"]);

                // Packet loss
                //PacketsSent TXPacketsLost
                if (prevTxPktLoss != 0 && prevTxPktSent != 0)
                {
                    double txPktSent = Convert.ToUInt64(obj["PacketsSent"]) - prevTxPktSent;
                    double txPktLost = Convert.ToUInt64(obj["TXPacketsLost"]) - prevTxPktLoss;
                    txPktLoss = txPktLost / (txPktLost + txPktSent);
                    if (txPktLoss > txPktLossPeak) txPktLossPeak = txPktLoss;
                }
                prevTxPktLoss = Convert.ToUInt64(obj["TXPacketsLost"]);
                prevTxPktSent = Convert.ToUInt64(obj["PacketsSent"]);

            }

            // Poll PCoIP CPU Stats
            searcher.Query = pcoipCPUQuery;
            foreach (ManagementObject obj in searcher.Get())
            {
                if (prevPCoIPCPUUtil != 0 && prevPCoIPCPUTime != 0)
                {
                    double pcoipCPUDiff = (Convert.ToUInt64(obj["PercentProcessorTime"]) - prevPCoIPCPUUtil);
                    double pcoipCPUTimeDiff = (Convert.ToUInt64(obj["TimeStamp_Sys100NS"]) - prevPCoIPCPUTime);
                    pcoipCPUUtil = (pcoipCPUDiff / pcoipCPUTimeDiff) / Environment.ProcessorCount;
                    if (pcoipCPUUtil > pcoipCPUUtilPeak) pcoipCPUUtilPeak = pcoipCPUUtil;
                }
                prevPCoIPCPUUtil = Convert.ToUInt64(obj["PercentProcessorTime"]);
                prevPCoIPCPUTime = Convert.ToUInt64(obj["TimeStamp_Sys100NS"]);
            }

            // Poll Image Stats
            searcher.Query = imageQuery;
            foreach (ManagementObject obj in searcher.Get())
            {
                if (prevImgTxBW != 0)
                {
                    imageTxBW = ((Convert.ToUInt64(obj["ImagingBytesSent"]) - prevImgTxBW) * 8) / 1024.0 / (timerInterval / 1000);
                    if (imageTxBW > imgTxBWPeak) imgTxBWPeak = imageTxBW;
                }
                prevImgTxBW = Convert.ToUInt64(obj["ImagingBytesSent"]);

                imgFPS = Convert.ToUInt64(obj["ImagingEncodedFramesPersec"]);
                if (imgFPS > imgFPSPeak) imgFPSPeak = imgFPS;
            }

            // Poll Network Stats
            searcher.Query = networkQuery;
            foreach (ManagementObject obj in searcher.Get())
            {
                netLatency = Convert.ToUInt64(obj["RoundTripLatencyms"]);
                if (netLatency > netLatencyPeak) netLatencyPeak = netLatency;

                activeTxBWLimit = Convert.ToUInt64(obj["TXBWActiveLimitkbitPersec"]);
            }

            // Poll Audio Stats
            searcher.Query = audioQuery;
            foreach (ManagementObject obj in searcher.Get())
            {
                if (prevAudTxBW != 0)
                {
                    audioTxBW = ((Convert.ToUInt64(obj["AudioBytesSent"]) - prevAudTxBW) * 8) / 1024.0 / (timerInterval / 1000);
                    if (audioTxBW > audTxBWPeak) audTxBWPeak = audioTxBW;
                }
                prevAudTxBW = Convert.ToUInt64(obj["AudioBytesSent"]);
            }
        }
    }
}
