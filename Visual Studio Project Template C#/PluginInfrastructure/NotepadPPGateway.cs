﻿// NPP plugin platform for .Net v0.91.57 by Kasper B. Graversen etc.
using System;
using System.Text;
using NppPluginNET.PluginInfrastructure;

namespace Kbg.NppPluginNET.PluginInfrastructure
{
	public interface INotepadPPGateway
	{
		void FileNew();

		string GetCurrentFilePath();
		unsafe string GetFilePath(int bufferId);
		void SetCurrentLanguage(LangType language);
	}

	/// <summary>
	/// This class holds helpers for sending messages defined in the Msgs_h.cs file. It is at the moment
	/// incomplete. Please help fill in the blanks.
	/// </summary>
	public class NotepadPPGateway : INotepadPPGateway
	{
		private const int Unused = 0;

		public void FileNew()
		{
			Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_MENUCOMMAND, Unused, NppMenuCmd.IDM_FILE_NEW);
		}

		/// <summary>
		/// Gets the path of the current document.
		/// </summary>
		public string GetCurrentFilePath()
		{
			var path = new StringBuilder(2000);
			Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_GETFULLCURRENTPATH, 0, path);
			return path.ToString();
		}

		/// <summary>
		/// Gets the path of the current document.
		/// </summary>
		public unsafe string GetFilePath(int bufferId)
		{
			var path = new StringBuilder(2000);
			Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_GETFULLPATHFROMBUFFERID, bufferId, path);
			return path.ToString();
		}

		public void SetCurrentLanguage(LangType language)
		{
			Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_SETCURRENTLANGTYPE, Unused, (int) language);
		}
	}
}