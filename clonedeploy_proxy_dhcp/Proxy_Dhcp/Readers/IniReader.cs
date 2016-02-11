﻿using System;
using System.Diagnostics;
using System.IO;
using IniParser;

namespace CloneDeploy_Proxy_Dhcp.Readers
{
    internal class IniReader
    {
        public void CheckForConfig()
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"config.ini"))
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"config.ini"))
                    {
                        writer.WriteLine(";Config File For Clone Deploy Proxy DHCP Server");
                        writer.WriteLine(";See the readme for more details");
                        writer.WriteLine("[settings]");
                        writer.WriteLine("listen-discover=true");
                        writer.WriteLine("listen-proxy=true");
                        writer.WriteLine("interface=");
                        writer.WriteLine("next-server=");
                        writer.WriteLine("allow-all-mac=true");
                        writer.WriteLine("bios-bootfile=");
                        writer.WriteLine("efi32-bootfile=");
                        writer.WriteLine("efi64-bootfile=");
                        writer.WriteLine("apple-mode=disabled");
                        writer.WriteLine("apple-boot-file=");
                        writer.WriteLine("apple-root-path=\"\"");
                        writer.WriteLine("apple-vendor-specific-information=01:01:01:04:02:FF:FF:07:04:01:00:07:D9:08:04:01:00:07:D9:09:0C:01:00:07:D9:07:4E:65:74:42:6F:6F:74");
                    }
                }
                catch
                {
                    Trace.TraceError("Could Not Locate Or Create config.ini");
                    throw;
                }

            }
        }

        public string ReadConfig(string key)
        {
            var ini = new FileIniDataParser();
            try
            {
                var parsedData = ini.LoadFile(AppDomain.CurrentDomain.BaseDirectory + @"config.ini");
                return parsedData["settings"][key];
            }
            catch
            {
                // ignored
            }
            return null;
        }
    }
}
