﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    class Normatization
    {
        public static string NormatizeString(string palavra)
        {
            //Remove espaços no começo e no fim da string.
            palavra = palavra.Trim();
            //Remove espaços entre as palavras.
            palavra = Regex.Replace(palavra, @"\s+", " ");

            TextInfo textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
            palavra = textInfo.ToTitleCase(palavra);

            return palavra;
        }
    }
}
