using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using H3VRModInstaller.Common;
using H3VRModInstaller.Filesys;
using H3VRModInstaller.JSON;
using H3VRModInstaller.Net;
using AutoUpdaterDotNET;

namespace H3VRModInstaller.Frontend
{
    public static class Actions
    {
        private static string relevantCategory = "";
        public static Tuple<ModFile[], ModFile[]> GetRelevantMods()
        {
            return GetRelevantMods(relevantCategory);
        }
        
        public static Tuple<ModFile[], ModFile[]> GetRelevantMods(string category)
        {
            relevantCategory = category; //set new relevantcat
            ModFile[] DLmods = new ModFile[0];
            
            //get downloadable mods, all or select category
            if (category == "" || category == "all") { DLmods = ModParsing.GetAllMods(); }
            else { DLmods = JsonModList.GetDeserializedModListFormatOnline(category).Modlist; }
            ModFile[] ILmods = InstalledMods.GetInstalledMods(); //get all installed mods

            List<ModFile> resultDLmods = new List<ModFile>(); //i've never actually used a List before! --potatoes
            List<ModFile> resultILmods = new List<ModFile>(); //that's why 95% of my array code uses resize. oh well, who needs speed!

            for (int i = 0; i < DLmods.Length; i++)
            {
                bool inILmods = false;
                for (int x = 0; x < ILmods.Length; x++)
                {
                    if (DLmods[i].ModId == ILmods[i].ModId) { inILmods = true; break; } //if in ilmods, set to true
                }
                if (inILmods) { resultILmods.Add(ILmods[i]); } //if overlap btwn dl&il, put to il
                else { resultDLmods.Add(DLmods[i]); } //otherwise, put to dl
                //this also means that if there is an il but no dl, it is discarded.
            }

            return new Tuple<ModFile[], ModFile[]>(resultDLmods.ToArray(), resultILmods.ToArray());
        }
        
        public static void GotoWebsite(ModFile mf)
        {
            var link = mf.Website;
            var psi = new ProcessStartInfo
            {
                FileName = link,
                UseShellExecute = true
            };
            Process.Start(psi);
        }
        
        public static bool CheckIfILmodOutOfDate(ModFile mf)
        {
            Version ILver = new Version(mf.Version);
            Version DLver = new Version(ModParsing.GetSpecificMod(mf.ModId).Version);
            if (ILver.CompareTo(DLver) < 0) //if out of date
            {
                return true;
            }
            return false;
        }
        
        public static bool CheckIfILmodDisabled(ModFile mf)
        {
            
            if (!String.IsNullOrEmpty(mf.DelInfo))
            {
                //Location of where the mod should be to load
                string InstLoc = Path.Combine(Utilities.GameDirectory, mf.DelInfo.Split('?')[0]);
                //last part of a dir, eg dir1/dir2.jpeg > dir2.jpeg
                string DisLocPostFix = new DirectoryInfo(mf.DelInfo.Split('?')[0]).Name;
                //Location of where the mod should be to be disabled
                string DisLoc = Path.Combine(Utilities.DisableCache, DisLocPostFix);
                //if it does not exist to run, but is disabled
                if (!funcUtils.FileOrDirExists(InstLoc) && funcUtils.FileOrDirExists(DisLoc))
                {
                    return true;
                }
            } else { Console.WriteLine("Delinfo of {0} is empty!", mf.ModId);}
            return false;
        }
        
        public static bool CheckIfIncompatable(ModFile mf, ModFile[] mfs)
        {
            if (mf.IncompatableMods == null) { return false; }
            List<ModFile> incompatableMods = new List<ModFile>();
            
            //make sure no mods have null incompatablemods
            List<ModFile> mfslist = mfs.ToList();
            for (int i = 0; i < mfslist.Count; i++)
            {
                if (mfslist[i].IncompatableMods == null)
                {
                    mfslist.RemoveAt(i);
                }
            }
            mfs = mfslist.ToArray();
            
            for (int i = 0; i < mfs.Length; i++) {
                for (int incmods = 0; incmods < mf.IncompatableMods.Length; incmods++)
                {
                    if (mfs[i].ModId == mf.IncompatableMods[incmods]) { return true; }
                }
            }
            return false;
        }

        public static string[] GetAllSingularModCatagories()
        {
            List<ModFile> mf = ModParsing.GetAllMods().ToList();
            List<string> SMC = new List<string>();
            for (int i = 0; i < mf.Count; i++) //remove all mods that aren't relevant
            {
                if (mf[i].SingularModData == null)
                {
                    mf.RemoveAt(i);
                }
            }
            for (int i = 0; i < mf.Count; i++) //for every relevant modfile
            {
                for (int x = 0; x < mf[i].SingularModData.Occupys.Length; x++) //for every place it occupies
                {
                    if (!SMC.Contains(mf[i].SingularModData.Occupys[x])) //if it already isnt in the SMC data
                    {
                        SMC.Add(mf[i].SingularModData.Occupys[x]); //add
                    }
                }
            }
            return SMC.ToArray();
        }
        
        public static void GetModInstallerVersion()
        {
            AutoUpdater.InstalledVersion = Utilities.ModInstallerVersion;
            AutoUpdater.Start(Utilities.UpdateInfoPath);
            //displays screen if out of date, updates automatically. no downside other than it uses fucking xml -- potaotes
            //also note it gets the current ver from the assembly file ver, so make sure to update that!
        }
    }
}
