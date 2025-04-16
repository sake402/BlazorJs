// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Linq;
using System.Threading.Tasks;
using static H5.Core.dom;
using static H5.Core.es5;

namespace Microsoft.AspNetCore.Components.Forms
{
    internal static partial class InputFileInterop
    {
        //private const string JsFunctionsPrefix = "Blazor._internal.InputFile.";

        //public const string Init = JsFunctionsPrefix + "init";

        //public const string ReadFileData = JsFunctionsPrefix + "readFileData";

        //public const string ToImageFile = JsFunctionsPrefix + "toImageFile";


        public static void Init(IInputFileJsCallbacks callbackWrapper, HTMLInputElement elem)
        {
            elem["_blazorInputFileNextFileId"] = 0;

            elem.addEventListener("click", () =>
            {
                // Permits replacing an existing file with a new one of the same file name.
                elem.value = "";
            });

            elem.addEventListener("change", () =>
            {
                // Reduce to purely serializable data, plus an index by ID.
                elem["_blazorFilesById"] = new object();
                var fileList = elem.files.Select(file =>
                {
                    var id = elem["_blazorInputFileNextFileId"].As<int>();
                    id++;
                    elem["_blazorInputFileNextFileId"] = id;
                    var result = new BrowserFile
                    {
                        Id = id,
                        LastModified = DateTimeOffset.Parse(new Date(file.lastModified).toISOString()),
                        Name = file.name,
                        Size = (long)file.size,
                        ContentType = file.type,
                        //readPromise = undefined,
                        //arrayBuffer = undefined,
                        //blob: file,
                    };

                    result["blob"] = file;

                    elem["_blazorFilesById"][result.Id.ToString()] = result;

                    return result;

                }).ToArray();

                callbackWrapper.NotifyChange(fileList);
            });
        }


        static BrowserFile GetFileById(HTMLInputElement elem, int fileId)
        {
            var file = elem["_blazorFilesById"][fileId.ToString()].As<BrowserFile>();

            if (file == null)
            {
                throw new Exception($"There is no file with ID {fileId}.The file list may have changed.See https://aka.ms/aspnet/blazor-input-file-multiple-selections.");
            }

            return file;
        }

        public static Promise<Blob> ReadFileData(HTMLInputElement elem, int fileId)
        {
            var file = GetFileById(elem, fileId);
            return file["blob"].As<Promise<Blob>>();
        }

        public static async Task<BrowserFile> ToImageFile(HTMLInputElement elem, int fileId, string format, int maxWidth, int maxHeight)
        {
            var originalFile = GetFileById(elem, fileId);

            TaskCompletionSource<HTMLImageElement> tcs = new TaskCompletionSource<HTMLImageElement>();

            var originalFileImage = H5.Script.Write<object>("new Image()").As<HTMLImageElement>();
            originalFileImage["onload"] = (Action)(() =>
            {
                URL.revokeObjectURL(originalFileImage.src);
                tcs.SetResult(originalFileImage);
            });
            originalFileImage["onerror"] = (Action)(() =>
            {
                originalFileImage.onerror = null;
                URL.revokeObjectURL(originalFileImage.src);
            });
            originalFileImage["src"] = URL.createObjectURL(originalFile["blob"]);

            HTMLImageElement loadedImage = await tcs.Task;
            //HTMLImageElement loadedImage = new Promise((Action<HTMLImageElement> resolve) =>
            //{
            //    var originalFileImage = H5.Script.Write<object>("new Image()").As<HTMLImageElement>();
            //    originalFileImage["onload"] = () =>
            //    {
            //        URL.revokeObjectURL(originalFileImage.src);
            //        resolve(originalFileImage);
            //    };
            //    originalFileImage["onerror"] = () =>
            //    {
            //        originalFileImage.onerror = null;
            //        URL.revokeObjectURL(originalFileImage.src);
            //    };
            //    originalFileImage["src"] = URL.createObjectURL(originalFile["blob"]);
            //});

            TaskCompletionSource<Blob> tcs2 = new TaskCompletionSource<Blob>();
            var desiredWidthRatio = H5.Core.es5.Math.min(1, maxWidth / loadedImage.width);
            var desiredHeightRatio = H5.Core.es5.Math.min(1, maxHeight / loadedImage.height);
            var chosenSizeRatio = H5.Core.es5.Math.min(desiredWidthRatio, desiredHeightRatio);

            var canvas = document.createElement("canvas").As<HTMLCanvasElement>();
            canvas.width = H5.Core.es5.Math.round(loadedImage.width * chosenSizeRatio).As<uint>();
            canvas.height = H5.Core.es5.Math.round(loadedImage.height * chosenSizeRatio).As<uint>();
            canvas.getContext("2d").As<CanvasRenderingContext2D>()?.drawImage(loadedImage, 0, 0, canvas.width, canvas.height);
            canvas.toBlob((blob) =>
            {
                tcs2.SetResult(blob);
            }, format);

            var resizedImageBlob = await tcs2.Task;

            //var resizedImageBlob = new Promise((Action<BlobCallback> resolve) =>
            //{
            //    var desiredWidthRatio = Math.min(1, maxWidth / loadedImage.width);
            //    var desiredHeightRatio = Math.min(1, maxHeight / loadedImage.height);
            //    var chosenSizeRatio = Math.min(desiredWidthRatio, desiredHeightRatio);

            //    var canvas = document.createElement("canvas").As<HTMLCanvasElement>();
            //    canvas.width = Math.round(loadedImage.width * chosenSizeRatio);
            //    canvas.height = Math.round(loadedImage.height * chosenSizeRatio);
            //    canvas.getContext("2d").As<CanvasRenderingContext2D>()?.drawImage(loadedImage, 0, 0, canvas.width, canvas.height);
            //    canvas.toBlob(resolve, format);
            //});

            var id = elem["_blazorInputFileNextFileId"].As<int>();
            id++;
            elem["_blazorInputFileNextFileId"] = id;

            var result = new BrowserFile
            {
                Id = id,
                LastModified = originalFile.LastModified,
                Name = originalFile.Name,
                Size = (long)(resizedImageBlob?.size ?? 0),
                ContentType = format,
            };

            result["blob"] = resizedImageBlob ?? originalFile["blob"];
            elem["_blazorFilesById"][result.Id.ToString()] = result;

            return result;
        }


    }
}