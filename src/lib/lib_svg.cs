using System;
using System.Drawing;
using LamedalCore.zz;
using LamedalCore_Templates;
using LamedalCore_Templates.Enumerals;

namespace LamedalCore.lib
{
    public sealed class lib_svg
    {
        public string Badge(string subject, string status, string statusColor, float subjectWidth, float statusWidth, enBadgeStyle style = enBadgeStyle.Flat)
        {
            string template = Templates.BadgeStyle(style);
            float totalWidth = subjectWidth + statusWidth;

            var result = template.zFormat(totalWidth, subjectWidth, statusWidth, subjectWidth / 2 + 1, subjectWidth + statusWidth / 2 - 1, subject, status, statusColor);
            return result;
        }
    }
}