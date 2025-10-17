using HospitalManagerment.DAO;
using HospitalManagerment.DTO;
using HospitalManagerment.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HospitalManagerment.BUS
{
    internal class PatientWithHIBUS
    {
        private readonly PatientBUS patientBUS = new PatientBUS();
        private readonly HealthInsuranceBUS bhytBUS = new HealthInsuranceBUS();

        public bool AddPatientWithOptionalBHYT(PatientDTO patient, HealthInsuranceDTO bhyt, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                if (bhyt != null)
                {
                    // Bước 1: Thêm BHYT trước
                    if (!bhytBUS.AddHealthInsurance(bhyt, out errorMessage))
                        return false;

                    // Gán khóa ngoại cho bệnh nhân
                    patient.SoBHYT = bhyt.SoBHYT;
                }

                // Bước 2: Thêm bệnh nhân
                return patientBUS.AddPatient(patient, out errorMessage);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}
