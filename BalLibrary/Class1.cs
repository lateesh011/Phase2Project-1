using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalLib;

namespace BalLibrary
{
    public class deptmethods
    {
        MyContext context = new MyContext();
        public deptmethods()
        {
            context = new MyContext();
        }
        public bool adddeptmaster(DeptMaster p)
        {
            try
            {
                DeptMaster k = new DeptMaster();
                k.DeptCode = p.DeptCode;
                k.DeptName = p.DeptName;
                context.DeptTable.Add(k);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool removemaster(int id)
        {
            try
            {
                List<DeptMaster> p = context.DeptTable.ToList();
                DeptMaster k = p.Find(p1 => p1.DeptCode == id);
                context.DeptTable.Remove(k);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool updatemaster(int id, DeptMaster k)
        {
            try
            {
                List<DeptMaster> p = context.DeptTable.ToList();
                DeptMaster s = p.Find(p1 => p1.DeptCode == id);
                s.DeptCode = Convert.ToInt32(k.DeptCode);
                s.DeptName = k.DeptName;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public DeptMaster finddept(int id)
        {
            List<DeptMaster> p = context.DeptTable.ToList();
            DeptMaster k = p.Find(p1 => p1.DeptCode == id);
            return k;
        }
        public List<DeptMaster> getdeptMasters()
        {

            return context.DeptTable.ToList();
        }
    }
    public class empmethods
    {
        MyContext context = null;
        public empmethods()
        {
            context = new MyContext();
        }
        public bool AddEmployee(EmpProfile m)
        {
            try
            {
                context.EmpTable.Add(m);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateEmployee(int id, EmpProfile m)
        {
            try
            {
                List<EmpProfile> p = context.EmpTable.ToList();
                EmpProfile s = p.Find(p1 => p1.EmpCode == id);
                s.EmpCode = Convert.ToInt32(m.EmpCode);
                s.EmpName = m.EmpName;
                s.DateOfBirth = m.DateOfBirth;
                s.Email = m.Email;
                s.DeptCode = m.DeptCode;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Removemployee(int id)
        {
            try
            {
                List<EmpProfile> p = context.EmpTable.ToList();
                EmpProfile k = p.Find(p1 => p1.EmpCode == id);
                context.EmpTable.Remove(k);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<EmpProfile> getEmployee()
        {

            return context.EmpTable.ToList();
        }

        public EmpProfile findemp(int id)
        {
            List<EmpProfile> p = context.EmpTable.ToList();
            EmpProfile k = p.Find(p1 => p1.EmpCode == id);
            return k;
        }
    }
}
