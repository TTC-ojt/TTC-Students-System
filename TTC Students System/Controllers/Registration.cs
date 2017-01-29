namespace GN.TTC.Students.Controllers
{
    class Registration
    {
        internal Main cMain;

        internal Models.Program mProgram;
        internal Models.Batch mBatch;
        internal Models.Student mStudent;
        internal Models.Profile mProfile;
        internal Models.Contact mContact;
        internal Models.Training mTraining;
        internal Models.Employment mEmployment;
        internal Models.MATB mMATB;
        internal Models.NCAE mNCAE;
        internal Models.YP4SC mYP4SC;
        internal Models.Assessment mAssessment;
        internal Models.Document mDocument;
        internal Models.Insurance mInsurance;

        internal Views.Registration.ManPowerProfile vManPower;
        internal Views.Registration.PersonalInformation vPersonalInfo;
        internal Views.Registration.LearnerClassification vLearnerClassification;
        internal Views.Registration.Examinations vExaminations;

        internal Registration(Main cMain)
        {
            this.cMain = cMain;
            mStudent = new Models.Student();
            mProgram = new Models.Program();
            mBatch = new Models.Batch();
            mProfile = new Models.Profile();
            mContact = new Models.Contact();
            mTraining = new Models.Training();
            mEmployment = new Models.Employment();
            mMATB = new Models.MATB();
            mNCAE = new Models.NCAE();
            mYP4SC = new Models.YP4SC();
            mAssessment = new Models.Assessment();
            mDocument = new Models.Document();
            mInsurance = new Models.Insurance();
        }

        internal void ShowManPower()
        {
            if (vManPower == null)
            {
                vManPower = new Views.Registration.ManPowerProfile(this);
                vManPower.MdiParent = cMain.vMain;
            }
            vManPower.Show();
            if (vPersonalInfo != null) vPersonalInfo.Hide();
            if (vLearnerClassification != null) vLearnerClassification.Hide();
        }

        internal void ShowPersonalInfo()
        {
            if (vManPower != null) vManPower.Hide();
            if (vPersonalInfo == null)
            {
                vPersonalInfo = new Views.Registration.PersonalInformation(this);
                vPersonalInfo.MdiParent = cMain.vMain;
            }
            vPersonalInfo.Show();
            if (vLearnerClassification != null) vLearnerClassification.Hide();
        }

        internal void ShowLearnerClassification()
        {
            if (vManPower != null) vManPower.Hide();
            if (vPersonalInfo != null) vPersonalInfo.Hide();
            if (vLearnerClassification == null)
            {
                vLearnerClassification = new Views.Registration.LearnerClassification(this);
                vLearnerClassification.MdiParent = cMain.vMain;
            }
            vLearnerClassification.Show();
        }

        internal void ShowExaminations()
        {
            if (vExaminations == null)
            {
                vExaminations = new Views.Registration.Examinations(this);
            }
            vExaminations.ShowDialog();
        }

        internal void Close()
        {
            if (vManPower != null) vManPower.Close();
            if (vPersonalInfo != null) vPersonalInfo.Close();
            if (vLearnerClassification != null) vLearnerClassification.Close();
            cMain.vHome.Show();
        }

        internal void Save()
        {
            mStudent.BatchID = mBatch.ID;
            mStudent.Save();
            //profile
            mProfile.StudentID = mStudent.ID;
            mProfile.Save();
            //contact
            mContact.StudentID = mStudent.ID;
            mContact.Save();
            //training
            mTraining.StudentID = mStudent.ID;
            mTraining.Save();
            //employment
            mEmployment.StudentID = mStudent.ID;
            mEmployment.Type = "Before";
            mEmployment.Save();
            mEmployment = new Models.Employment();
            mEmployment.StudentID = mStudent.ID;
            mEmployment.Type = "After";
            mEmployment.Save();
            //matb
            mMATB.StudentID = mStudent.ID;
            mMATB.Save();
            //ncae
            mNCAE.StudentID = mStudent.ID;
            mNCAE.Save();
            //yp4sc
            mYP4SC.StudentID = mStudent.ID;
            mYP4SC.Save();
            //assessment
            mAssessment.StudentID = mStudent.ID;
            mAssessment.Save();
            //document
            mDocument.StudentID = mStudent.ID;
            mDocument.Save();
            //insurance
            mInsurance.StudentID = mStudent.ID;
            mInsurance.Save();
        }

    }
}
