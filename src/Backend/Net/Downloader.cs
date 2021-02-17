using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Threading;
using H3VRModInstaller.Common;
using H3VRModInstaller.Filesys;
using H3VRModInstaller.JSON;

namespace H3VRModInstaller.Net
{
    /// <summary>
    ///     This class is for downloading mods
    /// </summary>
    public class Downloader
    {
        /// <summary>
        ///     Stuff for the progress bar
        /// </summary>
        /// <param name="info">Float Array</param>
        public delegate void NotifyUpdate(float[] info);

        private static readonly WebClient _Downloader = new();
        private static bool _finished;

        /// <summary>
        ///     Download progress, should be private
        /// </summary>
        /// <value>Float array</value>
        public static string dlprogress;

        /// <summary>
        ///     (based dictionary) Dict for assigning a string to a modfile
        /// </summary>
        /// <returns>String, Modfile</returns>
        public Dictionary<string, ModFile> stringToModfile = new();

        /// <summary>
        ///     Downloads the mod specified
        /// </summary>
        /// <param name="fileinfo">ModFile, specify here which mod to use</param>
        /// <param name="modnum">Checks if mod already installed</param>
        /// <param name="autoredownload">Auto redownload?</param>
        /// <param name="skipdl">Skips the download process, mostly used for debugging</param>
        /// <returns>Boolean, true</returns>
        public static bool DownloadMod(ModFile fileinfo, int modnum, bool autoredownload = false, bool skipdl = false)
        {
            if (skipdl)
            {
                Installer.InstallMod(fileinfo);
                return true;
            }

            var installedmods = InstalledMods.GetInstalledMods();
            _finished = false;
            if (string.IsNullOrEmpty(fileinfo.RawName)) return false;

            var fileToDownload = fileinfo.RawName;
            var locationOfFile = fileinfo.Path;

            if (!autoredownload)
                for (var i = 0; i < installedmods.Length; i++)
                    if (fileinfo.ModId == installedmods[i].ModId)
                    {
                        if (modnum == 0)
                        {
                            Uninstaller.DeleteMod(fileinfo.ModId);
                        }
                        else
                        {
                            ModInstallerCommon.DebugLog(fileinfo.ModId + " is already installed!");
                            return false;
                        }
                    }

            var fileloc = new Uri(locationOfFile + fileToDownload);

            if (ModInstallerCommon.enableDebugging)
                Console.WriteLine("Downloading {0} from {1}{0}", fileToDownload, locationOfFile);


            Console.WriteLine("");

            _Downloader.DownloadFileCompleted += Dlcomplete;
            _Downloader.DownloadProgressChanged += Dlprogress;
            _Downloader.DownloadFileAsync(fileloc, fileToDownload);
            while (!_finished) Thread.Sleep(50);
            _finished = false;

            Console.WriteLine("Successfully Downloaded {0}", fileToDownload, locationOfFile);
            if (ModInstallerCommon.enableDebugging) Console.Write("from {1}{0}", fileToDownload, locationOfFile);

            Installer.InstallMod(fileinfo);

            InstalledMods.AddInstalledMod(fileinfo.ModId);
            return true;
        }

        /// <summary>
        ///     Sender function for the GUI progress bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void Dlcomplete(object sender, AsyncCompletedEventArgs e)
        {
            dlprogress = "";
            _finished = true;
        }


        /// <summary>
        ///     Reports on download progress
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Arguments</param>
        public static void Dlprogress(object sender, DownloadProgressChangedEventArgs e)
        {
            if ((float) e.TotalBytesToReceive <= 10)
            {
                var mbs = e.BytesReceived / 1000000f;
                var mbstext = string.Format("{0:00.00}", mbs);
                Console.Write("\r" + mbstext + "MBs downloaded!");
                dlprogress = mbstext + "MBs downloaded!";
            }
            else
            {
                var percentage = e.BytesReceived / (float) e.TotalBytesToReceive * 100;
                var percentagetext = string.Format("{0:00.00}", percentage);
                Console.Write("\r" + percentagetext + "% downloaded!");
                dlprogress = percentagetext + "% downloaded!";
            }

//            NotifyForms.CallEvent();
        }


        /// <summary>
        ///     Directs the mod downloading
        /// </summary>
        /// <param name="mod">Mod to direct</param>
        /// <param name="skipdl">Skips the download process</param>
        /// <returns>Boolean, true</returns>
        public static bool DownloadModDirector(string mod, bool skipdl = false)
        {
            if (!NetCheck.isOnline(ModInstallerCommon.Pingsite))
            {
                Console.WriteLine("Not connected to internet, or " + ModInstallerCommon.Pingsite + " is down!");
                return false;
            }

            var result = ModParsing.GetModInfoAndDependencies(mod);
            if (result == null) return false;
            for (var i = 0; i < result.Length; i++)
                /*				string[] fileinfo = new string[5];
                                    fileinfo[0] = result.Item1[i, 0]; //File name
                                    fileinfo[1] = result.Item1[i, 1]; //File loc
                                    fileinfo[2] = result.Item1[i, 2]; //args
                                    fileinfo[3] = i.ToString(); //modnumber
                                    fileinfo[4] = result.Item1[i, 3]; //File ID*/
                DownloadMod(result[i], i, false, skipdl);
            return true;
        }

/*        /// <summary>
        ///     Class for notifying forms to update the progress bar
        /// </summary>
        public static class NotifyForms
        {
            /// <summary>
            ///     Object for notifying forms to update the progress bar
            /// </summary>
            public static event NotifyUpdate NotifyUpdateProgressBar;

            /// <summary>
            ///     Function for notifying forms to update the progress bar
            /// </summary>
            public static void CallEvent()
            {
                NotifyUpdateProgressBar?.Invoke(dlprogress);
            }
        }*/
    }
}