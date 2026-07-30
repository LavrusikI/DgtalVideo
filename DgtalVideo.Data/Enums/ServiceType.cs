using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DgtalVideo.Data.Enums
{
    public enum ServiceType
    {
        ЦветокоррекцияНет = 0,
        ЦветокоррекцияДа = 400,
    }
    public enum VolumeOfSourceFiles
    {
        ОбъемИсходниковДо5Гб = 600,
        ОбъемИсходниковДо15Гб = 1000,
        ОбъемИсходниковДо50Гб = 1500,
    }
    public enum Subtitles
    {
        СубтитрыНеНужны = 0,
        СубтитрыНужны = 300,
    }
    public enum Urgency
    {
        НеСрочно = 0,
        Срочно = 650,
    }
    public enum Format
    {
        Reels = 200,
        YouTube = 350,
        СвадебныйТизер = 2000,
        Промо = 2500,
    }
}
