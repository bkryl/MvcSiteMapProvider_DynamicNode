using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcSiteMapProvider;

namespace MvcSiteMapProvider_DynamicNode
{
    public class DepartmentNodeProvider
        : DynamicNodeProviderBase
    {
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var Departments = DepartmentGetter.GetDepartments();

            foreach (Department dep in Departments)
            {
                DynamicNode dynamicNode = new DynamicNode { Title = dep.Name };
                dynamicNode.RouteValues.Add("acronym", dep.Acronym);
                yield return dynamicNode;
            }
        }
    }

    public class DepartmentGetter
    {
        public static IEnumerable<Department> GetDepartments()
        {
            var Departments = new Department[] 
            { 
                new Department() { Id = 1, Name = "First Department", Acronym = "ABCD" }, 
                new Department() { Id = 2, Name = "Second Department", Acronym = "EFGH" },
                new Department() { Id = 3, Name = "Third Department", Acronym = "IJKL" },
                new Department() { Id = 4, Name = "Fourth Department", Acronym = "MNOP" } 
            };
            return Departments;
        }
    }

    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Acronym { get; set; }
    }
}