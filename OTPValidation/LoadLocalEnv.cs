using DotNetEnv;

namespace OTPValidation.API
{
    public static class LoadLocalEnv
    {
        public static void Load()
        {
            const string FileName = ".env";
            LoadEnviroment(FileName);
            var file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileName);
            if (File.Exists(file))
                Env.Load(file);
        }

        private static void LoadEnviroment(in string fileName)
        {
            var file = Path.Combine(GetPath(fileName)?.FullName ?? string.Empty, fileName);

            var dirTarget = AppDomain.CurrentDomain.BaseDirectory;
            var dirSource = Path.Combine(dirTarget, fileName);

            if (!File.Exists(file))
                return;

            var streamReader = File.OpenText(file);
            string fileInText = streamReader.ReadToEnd();
            streamReader.Close();


            var fileInfo = new FileInfo(dirSource);
            var streamWriter = fileInfo.CreateText();
            streamWriter.Write(fileInText);
            streamWriter.Close();
        }
        private static DirectoryInfo GetPath(string fileName)
        {
            var dir = Directory.GetParent(Directory.GetCurrentDirectory());
            while (dir != null && !dir.GetFiles(fileName).Any())
            {
                dir = dir.Parent;
            }

            return dir;
        }
    }

}

