﻿// <copyright file="FileFacade.cs" company="Automate The Planet Ltd.">
// Copyright 2024 Automate The Planet Ltd.
// Licensed under the Apache License, Version 2.0 (the "License");
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// <author>Anton Angelov</author>
// <site>https://bellatrix.solutions/</site>
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Bellatrix.Infrastructure;

public class FileFacade
{
    public void Copy(string sourceFileName, string destFileName, bool overwrite) => File.Copy(sourceFileName, destFileName, overwrite);

    public void WriteAllText(string path, string contents) => File.WriteAllBytes(path, Encoding.UTF8.GetBytes(contents));

    public string ReadAllText(string path) => File.ReadAllText(path);

    public void Delete(string path) => File.Delete(path);

    public void CreateZip(string sourceDirectoryPath, string zipPath) => ZipFile.CreateFromDirectory(sourceDirectoryPath, zipPath);

    public void ExtractZip(string zipPath, string extractPath) => ZipFile.ExtractToDirectory(zipPath, extractPath);

    public byte[] ReadAllBytes(string filePath) => File.ReadAllBytes(filePath);

    public void WriteAllBytes(string filePath, byte[] fileData) => File.WriteAllBytes(filePath, fileData);

    public bool Exists(string filePath) => File.Exists(filePath);

    public bool IsWithExtension(string filePath, string extension)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("The specified file does not exist", filePath);
        }

        var fileInfo = new FileInfo(filePath);
        return fileInfo.Extension.Equals(extension);
    }

    public string CreateTempFile(string extension)
    {
        string fileName = Path.GetRandomFileName();
        fileName = Path.ChangeExtension(fileName, extension);
        fileName = Path.Combine(Path.GetTempPath(), fileName);
        File.Create(fileName);
        return fileName;
    }
}