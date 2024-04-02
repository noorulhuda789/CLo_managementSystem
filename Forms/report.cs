using DBMidProject.Bl;
using PdfSharp.Charting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMidProject.Forms
{
    public partial class report : Form
    {
        List<String> studentInfoList = new List<String>();
        public report()
        {
            InitializeComponent();
            filldata();
        }

        private void filldata()
        {
            try
            {
                List<string> registrationNumbers = new List<string>();
                string query = @"Select RegistrationNumber From Student Where Status = 5";
                var con = Configuration.getInstance().getConnection();
                SqlCommand command = new SqlCommand(query, con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    registrationNumbers.Add(reader.GetString(0));
                }
                reader.Close();
                student.DataSource= registrationNumbers;
            } catch (Exception ex) { MessageBox.Show(ex.Message); } 



        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            string query = @"SELECT s.RegistrationNumber, ca.AttendanceDate AS ClassDate, 
                                l.Name AS AttendanceStatus 
                                FROM Student s JOIN StudentAttendance sa 
                                ON s.Id = sa.StudentId 
                                JOIN
                                ClassAttendance ca 
                                ON sa.AttendanceId = ca.Id 
                                JOIN Lookup l 
                                ON
                                sa.AttendanceStatus = l.LookupId 
                                WHERE s.RegistrationNumber = @RegistrationNumber;";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@RegistrationNumber", student.SelectedItem.ToString());
            DataTable dt = new DataTable();
            da.Fill(dt);
            AddTitle();
            foreach (string item in studentInfoList)
            {
                Console.WriteLine(item);
            }
            AdvancedPdfGenerator.GeneratePdf(dt, "Attendance Report of the Student", "D:\\dataBaseMidPoject\\dbmidproject-2022-cs-60\\images\\ORIGINAL ICON.png", studentInfoList);

        }
        private void AddTitle()
        {
            var con = Configuration.getInstance().getConnection();


            string query = @"
                                SELECT
                                    CONCAT(s.FirstName, ' ', s.LastName) AS StudentName,
                                    s.Email,
                                    ISNULL(SUM(CASE WHEN sa.AttendanceStatus = 1 THEN 1 ELSE 0 END) * 100.0 / COUNT(sa.StudentId), 0) AS AttendancePercentage
                                FROM
                                    Student s
                                LEFT JOIN
                                    StudentAttendance sa ON s.Id = sa.StudentId
                                WHERE s.RegistrationNumber = @RegistrationNumber
                                GROUP BY
                                    s.FirstName, s.LastName, s.Email, s.Id";

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@RegistrationNumber", student.SelectedItem.ToString());

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string studentName = reader["StudentName"].ToString();
                        string email = "Email: " + reader["Email"].ToString();
                        string attendancePercentage = "Attendance Percentage: " + Convert.ToDouble(reader["AttendancePercentage"]).ToString();
                        // Add items to the list
                        studentInfoList.Add(studentName);
                        studentInfoList.Add(email);
                        studentInfoList.Add(attendancePercentage);
                    }
                }
            }
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            string query = @"SELECT (SELECT RegistrationNumber FROM Student WHERE Id=S.Id)'Registration Number',
                            COUNT(*) 'Total Presents', (SELECT COUNT(*) FROM ClassAttendance CAT JOIN StudentAttendance SAT ON CAT.Id=SAT.AttendanceId) 'Total Classes Entered'
                            ,CAST((CAST(COUNT(*)  AS DECIMAL(16,2)) / CAST( (SELECT COUNT(*) FROM ClassAttendance CAT JOIN StudentAttendance SAT ON CAT.Id=SAT.AttendanceId) AS numeric(16,2)) * 100 ) as numeric(16, 2)) AS 'Percentage Attendance'
                            FROM StudentAttendance SA
                            JOIN Student S
                            ON S.Id=SA.StudentId
                            GROUP BY S.Id ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            studentInfoList.Clear();
            studentInfoList.Add("Attendance of All Classes"); 
            studentInfoList.Add(" Attendance  Percentage =Total Student Class/Total Classes *100"); 
            studentInfoList.Add("Active Students Only");
            AdvancedPdfGenerator.GeneratePdf(dt, "Attendance Percentage Report of the class", "D:\\dataBaseMidPoject\\dbmidproject-2022-cs-60\\images\\ORIGINAL ICON.png", studentInfoList);
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            string query = @"SELECT
                                        TT.StudentName AS Name,
                                        TT.Assessment,
                                        SUM(TT.[Obtained Marks]) AS 'Obtained',
                                        CAST((SUM(TT.[Obtained Marks]) * TT.TotalWeightage / SUM(TT.TotalMarks)) AS DECIMAL(16, 2)) AS Weighted
                                    FROM
                                        (SELECT 
                                            (SELECT CONCAT(S.FirstName, ' ', S.LastName) FROM Student S WHERE S.Id = SR.StudentID) AS StudentName,
                                            CONCAT(C.Id, '-', C.Name) AS 'CLO Title',
                                            CONVERT(date, SR.EvaluationDate) AS 'Evaluation Date',
                                            A.Title AS 'Assessment',
                                            AC.Name AS Component,
                                            AC.TotalMarks,
                                            RL.MeasurementLevel AS 'Examiners Measure',
                                            (SELECT MAX(RLP.MeasurementLevel) FROM RubricLevel RLP WHERE RLP.RubricId = R.Id) AS 'Max Measure',
                                            CAST(((CAST(RL.MeasurementLevel AS FLOAT) / CAST((SELECT MAX(RLP.MeasurementLevel) FROM RubricLevel RLP WHERE RLP.RubricId = R.Id) AS FLOAT))) * CAST(AC.TotalMarks AS FLOAT) AS DECIMAL(16, 2)) AS 'Obtained Marks',
                                            A.TotalWeightage
                                        FROM 
                                            Assessment A
                                        JOIN 
                                            AssessmentComponent AC ON AC.AssessmentId = A.Id
                                        JOIN 
                                            StudentResult SR ON SR.AssessmentComponentId = AC.Id
                                        JOIN 
                                            RubricLevel RL ON SR.RubricMeasurementId = RL.Id
                                        JOIN 
                                            Rubric R ON RL.RubricId = R.Id
                                        JOIN 
                                            Clo C ON R.CloId = C.Id
                                        JOIN 
                                            Student ON SR.StudentID = Student.Id  -- Fix here
                                        WHERE
                                            Student.RegistrationNumber = @StudentID  -- Fix here
                                        GROUP BY  
                                            A.Title, SR.StudentID, AC.Name, AC.TotalMarks, RL.Id, RL.MeasurementLevel, SR.RubricMeasurementId, R.Id, C.Name, C.Id, SR.EvaluationDate, A.TotalWeightage) TT
                                    GROUP BY 
                                        TT.StudentName, TT.Assessment, TT.TotalWeightage;";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@StudentID", student.SelectedItem.ToString());
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();

            dataAdapter.Fill(dataTable);
            AddTitle();
            AdvancedPdfGenerator.GeneratePdf(dataTable, "Assessment Wise Result for Student ", "D:\\dataBaseMidPoject\\dbmidproject-2022-cs-60\\images\\ORIGINAL ICON.png", studentInfoList);

        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            string query = "SELECT\r\n\tTT.StudentName AS Name,TT.Assessment,SUM(TT.[Obtained Marks]) 'Obtained',\r\n\tCAST((SUM(TT.[Obtained Marks])* TT.TotalWeightage / SUM(TT.TotalMarks)) AS DECIMAL(16,2) )Weighted\r\nFROM\r\n   (SELECT (SELECT CONCAT(S.FirstName,' ',S.LastName) FROM Student S  WHERE S.Id = SR.StudentID) StudentName,\r\n\tCONCAT(C.Id,'-',C.Name)'CLO Title',CONVERT(date,SR.EvaluationDate) 'Evaluation Date',A.Title 'Assessment',AC.Name as Component,AC.TotalMarks,RL.MeasurementLevel 'Examiners Measure',\r\n\t(SELECT MAX( RLP.MeasurementLevel) FROM RubricLevel RLP WHERE RLP.RubricId = R.Id) as 'Max Measure',\r\n\tCAST(((CAST(RL.MeasurementLevel AS FLOAT) / CAST((SELECT MAX( RLP.MeasurementLevel ) FROM RubricLevel RLP WHERE RLP.RubricId = R.Id)AS FLOAT))) * CAST(AC.TotalMarks AS FLOAT) AS DECIMAL(16,2))\r\n\t'Obtained Marks',A.TotalWeightage\r\n\tFROM Assessment A\r\n\tJOIN AssessmentComponent AC ON AC.AssessmentId = A.Id\r\n\tJOIN StudentResult SR ON SR.AssessmentComponentId = AC.Id\r\n\tJOIN RubricLevel RL ON SR.RubricMeasurementId = RL.Id\r\n\tJOIN Rubric R ON RL.RubricId = R.Id\r\n\tJOIN Clo C ON R.CloId = C.Id\r\n\tGROUP BY  A.Title,SR.StudentID,AC.Name,AC.TotalMarks,RL.Id,RL.MeasurementLevel,SR.RubricMeasurementId,R.Id,C.Name,C.Id,SR.EvaluationDate,A.TotalWeightage) TT\r\nGROUP BY TT.StudentName,TT.Assessment,TT.TotalWeightage;";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();

            dataAdapter.Fill(dataTable);
            studentInfoList.Clear();
            studentInfoList.Add("Assessment Reslut of All Classes");
            studentInfoList.Add(" Assessement =sum of Assessment Components ");
            studentInfoList.Add("Active Students Only");
            AdvancedPdfGenerator.GeneratePdf(dataTable, "Assessment Wise Result", "D:\\dataBaseMidPoject\\dbmidproject-2022-cs-60\\images\\ORIGINAL ICON.png", studentInfoList);
        
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Student where Status=6", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            studentInfoList.Clear();
            studentInfoList.Add("Inactive Students");
            studentInfoList.Add(" Students who have been graduated or dropped out");
            studentInfoList.Add(" ");
            dataAdapter.Fill(dataTable);
            AdvancedPdfGenerator.GeneratePdf(dataTable, "InActive Students", "D:\\dataBaseMidPoject\\dbmidproject-2022-cs-60\\images\\ORIGINAL ICON.png", studentInfoList);

        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            string query = @"SELECT Student.RegistrationNumber,CONCAT(Student.FirstName,' ',Student.LastName) 'Student Name',Clo.Name 'CLO '
                            ,CAST((SUM(((CAST(RL1.MeasurementLevel as FLOAT) * CAST(ACA.TotalMarks as FLOAT))/CAST(R1.[Maximum Level] as FLOAT))) / SUM(ACA.TotalMarks)) * 100 AS DECIMAL(16,2))'Percentage' 
                             FROM 
	                            (SELECT A.Id 'AssessmentID',
                                AC.Id 'AssessmentComponentId',
                                MAX(RL.MeasurementLevel) 'Maximum Level'
	                            FROM Assessment A 
	                            INNER JOIN AssessmentComponent AS AC ON A.Id = AC.AssessmentId 
	                            INNER JOIN RubricLevel AS RL ON RL.RubricId = AC.RubricId 
	                            GROUP BY A.Id,AC.Id) AS R1 
	                            JOIN StudentResult ON R1.AssessmentComponentId = StudentResult.AssessmentComponentId 
	                            JOIN AssessmentComponent AS ACA ON R1.AssessmentComponentId = ACA.Id 
	                            JOIN RubricLevel AS RL1 ON StudentResult.RubricMeasurementId = RL1.Id 
	                            JOIN Assessment ON Assessment.Id = R1.AssessmentID 
	                            JOIN Student ON Student.Id = StudentResult.StudentId 
	                            JOIN Rubric ON Rubric.Id = RL1.RubricId 
	                            JOIN Clo ON Rubric.CloId = Clo.Id 
	                         GROUP BY Student.RegistrationNumber,Clo.Name,Clo.Id,Student.FirstName,Student.LastName";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            studentInfoList.Clear();
            studentInfoList.Add("Clo Reslut of All Classes");
            studentInfoList.Add(" Clo =Percentage for all assessment components ");
            studentInfoList.Add("Active Students Only");
            AdvancedPdfGenerator.GeneratePdf(dt, "Clo Wise Result", "D:\\dataBaseMidPoject\\dbmidproject-2022-cs-60\\images\\ORIGINAL ICON.png", studentInfoList);

        }
    }
}
