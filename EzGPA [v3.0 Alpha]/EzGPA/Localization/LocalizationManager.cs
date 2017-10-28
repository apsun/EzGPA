using System;
using System.Collections.Generic;
using System.Diagnostics;
using EzGPA.Core;

namespace EzGPA.Localization
{
    public class LocalizationManager
    {
        public enum LocalizedStrings
        {
            AppName,
            Version,
            FullName,
            GradeName,
            CourseName,
            GroupName,
            LevelName,
            YourGpaIs,
            EnterAllScores,
            EnterValidScores,
            CopyToClipboard,
            CopiedToClipboard,
            CopyFailed,
            Options,
            About,
            Settings,
            AutoClear,
            AutoCopy,
            Language,
            Files,
            Info,
            Error,
            ResetSettingsMessage,
            DataMissingMessage,
            DataLoadFailedMessage,
            ConfigLoadFailedMessage,
            AboutMessage,
            Changelog
        }

        private readonly Dictionary<string, LocalizedString> _strings;

        public LocalizationManager(Dictionary<string, LocalizedString> localizedStrings)
        {
            _strings = localizedStrings;
        }

        private static object[] GetArgsWithToken(LookupToken token, object[] args)
        {
            object[] newArgs = new object[args.Length + 1];
            newArgs[0] = token;
            Array.Copy(args, 0, newArgs, 1, args.Length);
            return newArgs;
        }

        internal string GetLocalizedString(LookupToken token, string key, params object[] args)
        {
            // args[0] and token must refer to the same object
            token.MarkString(key);
            return _strings[key].Format(args);
        }

        public string GetLocalizedString(LocalizedStrings key, params object[] args)
        {
            Debug.WriteLine("Looking up localized string: " + key);
            LookupToken token = new LookupToken(this);
            args = GetArgsWithToken(token, args);
            return GetLocalizedString(token, key.ToString(), args);
        }

        public string AppName()
        {
            return GetLocalizedString(LocalizedStrings.AppName);
        }

        public string Version(Version version)
        {
            return GetLocalizedString(LocalizedStrings.Version, version);
        }

        public string FullName(Version version)
        {
            return GetLocalizedString(LocalizedStrings.FullName, version);
        }

        public string GradeName(Grade grade)
        {
            return GetLocalizedString(LocalizedStrings.GradeName, grade.Name);
        }

        public string CourseName(Course course)
        {
            return GetLocalizedString(LocalizedStrings.CourseName, course.Name);
        }

        public string GroupName(LevelGroup group)
        {
            return GetLocalizedString(LocalizedStrings.GroupName, group.Name);
        }

        public string LevelName(Level level)
        {
            return GetLocalizedString(LocalizedStrings.LevelName, level.Name);
        }

        public string YourGpaIs(double gpa)
        {
            return GetLocalizedString(LocalizedStrings.YourGpaIs, gpa);
        }

        public string EnterAllScores()
        {
            return GetLocalizedString(LocalizedStrings.EnterAllScores);
        }

        public string EnterValidScores()
        {
            return GetLocalizedString(LocalizedStrings.EnterValidScores);
        }

        public string CopyToClipboard()
        {
            return GetLocalizedString(LocalizedStrings.CopyToClipboard);
        }

        public string CopiedToClipboard()
        {
            return GetLocalizedString(LocalizedStrings.CopiedToClipboard);
        }

        public string CopyFailed()
        {
            return GetLocalizedString(LocalizedStrings.CopyFailed);
        }

        public string Options()
        {
            return GetLocalizedString(LocalizedStrings.Options);
        }

        public string About()
        {
            return GetLocalizedString(LocalizedStrings.About);
        }

        public string Settings()
        {
            return GetLocalizedString(LocalizedStrings.Settings);
        }

        public string AutoClear()
        {
            return GetLocalizedString(LocalizedStrings.AutoClear);
        }

        public string AutoCopy()
        {
            return GetLocalizedString(LocalizedStrings.AutoCopy);
        }

        public string Language()
        {
            return GetLocalizedString(LocalizedStrings.Language);
        }

        public string Files()
        {
            return GetLocalizedString(LocalizedStrings.Files);
        }

        public string Info()
        {
            return GetLocalizedString(LocalizedStrings.Info);
        }

        public string Error()
        {
            return GetLocalizedString(LocalizedStrings.Error);
        }

        public string ResetSettingsMessage()
        {
            return GetLocalizedString(LocalizedStrings.ResetSettingsMessage);
        }

        public string DataMissingMessage(string path)
        {
            return GetLocalizedString(LocalizedStrings.DataMissingMessage, path);
        }

        public string DataLoadFailMessage(string path, Exception ex)
        {
            return GetLocalizedString(LocalizedStrings.DataLoadFailedMessage, path, ex);
        }

        public string ConfigLoadFailMessage(Exception ex)
        {
            return GetLocalizedString(LocalizedStrings.ConfigLoadFailedMessage, ex);
        }

        public string AboutMessage(Version version)
        {
            return GetLocalizedString(LocalizedStrings.AboutMessage, Version(version));
        }

        public string Changelog()
        {
            return GetLocalizedString(LocalizedStrings.Changelog);
        }
    }
}
