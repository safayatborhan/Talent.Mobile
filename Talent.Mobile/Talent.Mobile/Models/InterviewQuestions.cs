using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Mobile.Models;

namespace Talent.Mobile.Models
{

    public class InterviewQuestions
    {
        public InterviewQuestions()
        {
            DepartmentList = new List<Department>();
            DesignationList = new List<Designation>();
            StreamList = new List<Stream>();
            IntQuesList = new List<IntQues>();
        }
        public List<Department> DepartmentList { get; set; }
        public List<Designation> DesignationList { get; set; }
        public List<Stream> StreamList { get; set; }
        public List<IntQues> IntQuesList { get; set; }

        public  int deptId { get; set; }
        public int desigId { get; set; }
        public int streamId { get; set; }
    }


    public class Stream
    {
        public int StreamID { get; set; }
        public Nullable<int> DegreeId { get; set; }
        public String StreamName { get; set; }
    }
    public class Department
    {
        public int DepartmentId { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public String DepartmentName { get; set; }
        public Nullable<int> Number { get; set; }
    }
    public class Designation
    {
        public int DesignationId { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public String DesignationName { get; set; }
    }
    public class IntQues
    {
        public IntQues(string a, string b)
        {
            IVSetQuestion = a;
            IVSetAnswer = b;
        }
        public string IVSetQuestion { get; set; }

        public string IVSetAnswer { get; set; }
    }

    public class InterviewSet
    {
        public int Id { get; set; }
        public Nullable<int> StreamId { get; set; }
        public Nullable<int> DesignationId { get; set; }
        public string IVSetQuestion { get; set; }
        public string IVSetAnswer { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<byte> IsDelete { get; set; }
    }
}
