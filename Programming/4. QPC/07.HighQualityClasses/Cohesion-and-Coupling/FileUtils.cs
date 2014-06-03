namespace Utils
{
    /// <summary>
    /// Provides methods for extracting file name and extension
    /// </summary>
    public static class FileUtils
    {
        /// <summary>
        /// Extracts the file extension from a filename.
        /// </summary>
        /// <param name="fileName">String representing a file name.</param>
        /// <returns>String representing the file extension.</returns>
        public static string GetFileExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return string.Empty;
            }

            string extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        /// <summary>
        /// Extracts the file name without extension from a given filename with extension.
        /// </summary>
        /// <param name="fileName">String representing a file name.</param>
        /// <returns>String representing the file name without extension.</returns>
        public static string GetFileNameWithoutExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return fileName;
            }

            string extension = fileName.Substring(0, indexOfLastDot);
            return extension;
        }
    }
}
