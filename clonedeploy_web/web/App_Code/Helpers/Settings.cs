﻿using BLL;

namespace Helpers
{
    public class Settings
    {
        public static string AdLoginDomain
        {
            get { return Setting.GetSetting("AD Login Domain").Value; }
        }

        public static string ClientReceiverArgs
        {
            get { return Setting.GetSetting("Client Receiver Args").Value; }
        }

        public static string DebugRequiresLogin
        {
            get { return Setting.GetSetting("Debug Requires Login").Value; }
        }

        public static string DefaultComputerView
        {
            get { return Setting.GetSetting("Default Computer View").Value; }
        }

        public static string DefaultKernel32
        {
            get { return "3.18.1"; }
        }

        public static string DefaultKernel64
        {
            get { return "3.18.1x64"; }
        }

        public static string EndPort
        {
            get { return Setting.GetSetting("Udpcast End Port").Value; }
        }

        public static string ForceSsL
        {
            get { return Setting.GetSetting("Force SSL").Value; }
        }

        public static string GlobalComputerArgs
        {
            get { return Setting.GetSetting("Global Computer Args").Value; }
        }

        

        public static string PrimaryStoragePath
        {
            get { return BLL.DistributionPoint.GetPrimaryDistributionPoint().PhysicalPath; }
        }

      

        public static string OnDemand
        {
            get { return Setting.GetSetting("On Demand").Value; }
        }

        public static string OnDemandRequiresLogin
        {
            get { return Setting.GetSetting("On Demand Requires Login").Value; }
        }

        public static string ProxyBiosFile
        {
            get { return Setting.GetSetting("Proxy Bios File").Value; }
        }

        public static string ProxyDhcp
        {
            get { return Setting.GetSetting("Proxy Dhcp").Value; }
        }

        public static string ProxyEfi32File
        {
            get { return Setting.GetSetting("Proxy Efi32 File").Value; }
        }

        public static string ProxyEfi64File
        {
            get { return Setting.GetSetting("Proxy Efi64 File").Value; }
        }

        public static string PxeMode
        {
            get { return Setting.GetSetting("PXE Mode").Value; }
        }

        public static string QueueSize
        {
            get { return Setting.GetSetting("Queue Size").Value; }
        }

      

        public static string RegisterRequiresLogin
        {
            get { return Setting.GetSetting("Register Requires Login").Value; }
        }

        public static string SenderArgs
        {
            get { return Setting.GetSetting("Sender Args").Value; }
        }

        public static string ServerIp
        {
            get { return Setting.GetSetting("Server IP").Value; }
        }

        public static string UniversalToken
        {
            get { return Setting.GetSetting("Universal Token").Value; }
        }

        public static string StartPort
        {
            get { return Setting.GetSetting("Udpcast Start Port").Value; }
        }

        public static string TftpPath
        {
            get { return Setting.GetSetting("Tftp Path").Value; }
        }

        public static string WebPath
        {
            get { return Setting.GetSetting("Web Path").Value; }
        }

        public static string WebServerPort
        {
            get { return Setting.GetSetting("Web Server Port").Value; }
        }

        public static string WebTaskRequiresLogin
        {
            get { return Setting.GetSetting("Web Task Requires Login").Value; }
        }

        public static string SmtpServer
        {
            get { return Setting.GetSetting("Smtp Server").Value; }
        }

        public static string SmtpPort
        {
            get { return Setting.GetSetting("Smtp Port").Value; }
        }

        public static string SmtpUsername
        {
            get { return Setting.GetSetting("Smtp Username").Value; }
        }

        public static string SmtpPassword
        {
            get { return Setting.GetSetting("Smtp Password Encrypted").Value; }
        }

        public static string SmtpMailFrom
        {
            get { return Setting.GetSetting("Smtp Mail From").Value; }
        }

        public static string SmtpMailTo
        {
            get { return Setting.GetSetting("Smtp Mail To").Value; }
        }

        public static string SmtpSsl
        {
            get { return Setting.GetSetting("Smtp Ssl").Value; }
        }

        public static string SmtpEnabled
        {
            get { return Setting.GetSetting("Smtp Enabled").Value; }
        }

        public static string RequireImageApproval
        {
            get { return Setting.GetSetting("Require Image Approval").Value; }
        }

        public static string MulticastDecompression
        {
            get { return Setting.GetSetting("Multicast Decompression").Value; }
        }

        public static string IpxeRequiresLogin
        {
            get { return Setting.GetSetting("Ipxe Requires Login").Value; }
        }
    
    }
}