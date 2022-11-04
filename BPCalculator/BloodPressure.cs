using System;
using System.ComponentModel.DataAnnotations;

namespace BPCalculator
{
    // BP categories
    public enum BPCategory
    {
        [Display(Name="Low Blood Pressure")] Low,
        [Display(Name="Ideal Blood Pressure")]  Ideal,
        [Display(Name="Pre-High Blood Pressure")] PreHigh,
        [Display(Name ="High Blood Pressure")]  High
    };

    public class BloodPressure
    {
        public const int SystolicMin = 70;
        public const int SystolicMax = 190;
        public const int DiastolicMin = 40;
        public const int DiastolicMax = 100;

        public const int LowSystolicUpper = 89;
        public const int IdealSystolicUpper = 119;
        public const int PreHighSystolicUpper = 139;

        public const int LowDiastolicUpper = 59;
        public const int IdealDiastolicUpper = 79;
        public const int PreHighDiastolicUpper = 89;


        [Range(SystolicMin, SystolicMax, ErrorMessage = "Invalid Systolic Value")]
        public int Systolic { get; set; }                       // mmHG

        [Range(DiastolicMin, DiastolicMax, ErrorMessage = "Invalid Diastolic Value")]
        public int Diastolic { get; set; }                      // mmHG

        // calculate BP category
        public BPCategory Category
        {
            get
            {
                int sys = this.Systolic;
                int dia = this.Diastolic;

                if (sys <= LowSystolicUpper && dia <= LowDiastolicUpper)
                {
                    return BPCategory.Low;
                }
                else if (sys <= IdealSystolicUpper && dia <= IdealDiastolicUpper)
                {
                    return BPCategory.Ideal;
                }
                else if (sys <= PreHighSystolicUpper && dia <= PreHighDiastolicUpper)
                {
                    return BPCategory.PreHigh;
                }
                else
                    return BPCategory.High; 
            }
        }
    }
}
