using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DgtalVideo.Data.Enums
{
    public enum ServiceType
    {
        Нет = 0,
        Да = 400,
    }
    public enum VolumeOfSourceFiles
    {
        ГБ5 = 600,
        ГБ15 = 1000,
        ГБ50 = 1500,
    }
    public enum Subtitles
    {
        Нет = 0,
        Да = 300,
    }
    public enum Urgency
    {
        Нет = 0,
        Да = 650,
    }
    public enum Format
    {
        Reels = 200,
        YouTube = 350,
        СвадебныйТизер = 2000,
        Промо = 2500,
    }
}
