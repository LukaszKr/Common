using System.Collections.Generic;
using System.IO;

namespace ProceduralLevel.Common.Helper
{
    public static class DirectoryInfoExt
    {
		public delegate bool FileFilterDelegate(FileInfo file);

		public static List<FileInfo> GetAllFilesRecursive(this DirectoryInfo directory, FileFilterDelegate filter = null)
		{
			List<FileInfo> files = new List<FileInfo>();
			directory.GetAllFilesRecursive(files, filter);
			return files;
		}

		public static void GetAllFilesRecursive(this DirectoryInfo directory, List<FileInfo> validFiles, FileFilterDelegate filter = null)
		{
			DirectoryInfo[] directories = directory.GetDirectories();
			FileInfo[] files = directory.GetFiles();
			for(int x = 0; x < files.Length; x++)
			{
				FileInfo file = files[x];
				if(filter == null || filter(file))
				{
					validFiles.Add(file);
				}
			}

			for(int x = 0; x < directories.Length; x++)
			{
				directories[x].GetAllFilesRecursive(validFiles, filter);
			}
		}
	}
}
