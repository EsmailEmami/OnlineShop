﻿using Microsoft.AspNetCore.Http;
using System.Drawing;
using System.Text.RegularExpressions;

namespace OnlineShop.Common.Extensions
{
    public static class FormFileExtension
    {
        public const int ImageMinimumBytes = 512;

        public static bool IsImage(this IFormFile postedFile)
        {
            if (postedFile.ContentType.ToLower() != "image/jpg" &&
                        postedFile.ContentType.ToLower() != "image/jpeg" &&
                        postedFile.ContentType.ToLower() != "image/pjpeg" &&
                        postedFile.ContentType.ToLower() != "image/gif" &&
                        postedFile.ContentType.ToLower() != "image/x-png" &&
                        postedFile.ContentType.ToLower() != "image/png")
            {
                return false;
            }

            if (Path.GetExtension(postedFile.FileName).ToLower() != ".jpg"
                && Path.GetExtension(postedFile.FileName).ToLower() != ".png"
                && Path.GetExtension(postedFile.FileName).ToLower() != ".gif"
                && Path.GetExtension(postedFile.FileName).ToLower() != ".jpeg")
            {
                return false;
            }


            return true;
        }

        /// <summary>
        /// this method will validate the file, if it is an image
        /// </summary>
        /// <param name="postedFile"></param>
        /// <returns></returns>
        public static bool ValidateImage(this IFormFile postedFile)
        {
            if (!postedFile.IsImage())
            {
                return true;
            }

            try
            {
                if (!postedFile.OpenReadStream().CanRead)
                {
                    return false;
                }
                if (postedFile.Length < ImageMinimumBytes)
                {
                    return false;
                }

                byte[] buffer = new byte[ImageMinimumBytes];
                postedFile.OpenReadStream().Read(buffer, 0, ImageMinimumBytes);
                string content = System.Text.Encoding.UTF8.GetString(buffer);
                if (Regex.IsMatch(content, @"<script|<html|<head|<title|<body|<pre|<table|<a\s+href|<img|<plaintext|<cross\-domain\-policy",
                    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Multiline))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            try
            {
                using (var bitmap = new Bitmap(postedFile.OpenReadStream()))
                {
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                postedFile.OpenReadStream().Position = 0;
            }

            return true;
        }
    }
}
