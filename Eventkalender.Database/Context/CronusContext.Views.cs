//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Data.Entity.Infrastructure.MappingViews;

[assembly: DbMappingViewCacheTypeAttribute(
    typeof(Eventkalender.Database.CronusContext),
    typeof(Edm_EntityMappingGeneratedViews.ViewsForBaseEntitySets79a8b1654cd691fdad042d38a74a77ef72f212ec42418186f84e717febd57b6a))]

namespace Edm_EntityMappingGeneratedViews
{
    using System;
    using System.CodeDom.Compiler;
    using System.Data.Entity.Core.Metadata.Edm;

    /// <summary>
    /// Implements a mapping view cache.
    /// </summary>
    [GeneratedCode("Entity Framework 6 Power Tools", "0.9.2.0")]
    internal sealed class ViewsForBaseEntitySets79a8b1654cd691fdad042d38a74a77ef72f212ec42418186f84e717febd57b6a : DbMappingViewCache
    {
        /// <summary>
        /// Gets a hash value computed over the mapping closure.
        /// </summary>
        public override string MappingHashValue
        {
            get { return "79a8b1654cd691fdad042d38a74a77ef72f212ec42418186f84e717febd57b6a"; }
        }

        /// <summary>
        /// Gets a view corresponding to the specified extent.
        /// </summary>
        /// <param name="extent">The extent.</param>
        /// <returns>The mapping view, or null if the extent is not associated with a mapping view.</returns>
        public override DbMappingView GetView(EntitySetBase extent)
        {
            if (extent == null)
            {
                throw new ArgumentNullException("extent");
            }

            var extentName = extent.EntityContainer.Name + "." + extent.Name;

            if (extentName == "CodeFirstDatabase.Employee")
            {
                return GetView0();
            }

            if (extentName == "CronusContext.Employee")
            {
                return GetView1();
            }

            return null;
        }

        /// <summary>
        /// Gets the view for CodeFirstDatabase.Employee.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView0()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Employee
        [CodeFirstDatabaseSchema.Employee](T1.[Employee.No_], T1.Employee_timestamp, T1.[Employee_First Name], T1.[Employee_Middle Name], T1.[Employee_Last Name], T1.Employee_Initials, T1.[Employee_Job Title], T1.[Employee_Search Name], T1.Employee_Address, T1.[Employee_Address 2], T1.Employee_City, T1.[Employee_Post Code], T1.Employee_County, T1.[Employee.Phone No_], T1.[Employee.Mobile Phone No_], T1.[Employee_E-Mail], T1.[Employee.Alt_ Address Code], T1.[Employee.Alt_ Address Start Date], T1.[Employee.Alt_ Address End Date], T1.Employee_Picture, T1.[Employee_Birth Date], T1.[Employee.Social Security No_], T1.[Employee_Union Code], T1.[Employee.Union Membership No_], T1.Employee_Sex, T1.[Employee.Country_Region Code], T1.[Employee.Manager No_], T1.[Employee.Emplymt_ Contract Code], T1.[Employee_Statistics Group Code], T1.[Employee_Employment Date], T1.Employee_Status, T1.[Employee_Inactive Date], T1.[Employee_Cause of Inactivity Code], T1.[Employee_Termination Date], T1.[Employee.Grounds for Term_ Code], T1.[Employee_Global Dimension 1 Code], T1.[Employee_Global Dimension 2 Code], T1.[Employee.Resource No_], T1.[Employee_Last Date Modified], T1.Employee_Extension, T1.Employee_Pager, T1.[Employee.Fax No_], T1.[Employee_Company E-Mail], T1.Employee_Title, T1.[Employee.Salespers__Purch_ Code], T1.[Employee.No_ Series])
    FROM (
        SELECT 
            T.No AS [Employee.No_], 
            T.Timestamp AS Employee_timestamp, 
            T.FirstName AS [Employee_First Name], 
            T.MiddleName AS [Employee_Middle Name], 
            T.LastName AS [Employee_Last Name], 
            T.Initials AS Employee_Initials, 
            T.JobTitle AS [Employee_Job Title], 
            T.SearchName AS [Employee_Search Name], 
            T.Address AS Employee_Address, 
            T.Address2 AS [Employee_Address 2], 
            T.City AS Employee_City, 
            T.PostCode AS [Employee_Post Code], 
            T.County AS Employee_County, 
            T.PhoneNo AS [Employee.Phone No_], 
            T.MobilePhoneNo AS [Employee.Mobile Phone No_], 
            T.Email AS [Employee_E-Mail], 
            T.AltAddressCode AS [Employee.Alt_ Address Code], 
            T.AltAddressStartDate AS [Employee.Alt_ Address Start Date], 
            T.AltAddressEndDate AS [Employee.Alt_ Address End Date], 
            T.Picture AS Employee_Picture, 
            T.BirthDate AS [Employee_Birth Date], 
            T.SocialSecurityNo AS [Employee.Social Security No_], 
            T.UnionCode AS [Employee_Union Code], 
            T.UnionMembershipNo AS [Employee.Union Membership No_], 
            T.Sex AS Employee_Sex, 
            T.CountryRegionCode AS [Employee.Country_Region Code], 
            T.ManagerNo AS [Employee.Manager No_], 
            T.EmploymentContractCode AS [Employee.Emplymt_ Contract Code], 
            T.StatisticsGroupCode AS [Employee_Statistics Group Code], 
            T.EmploymentDate AS [Employee_Employment Date], 
            T.Status AS Employee_Status, 
            T.InactiveDate AS [Employee_Inactive Date], 
            T.CauseOfInactivityCode AS [Employee_Cause of Inactivity Code], 
            T.TerminationDate AS [Employee_Termination Date], 
            T.GroundsForTermCode AS [Employee.Grounds for Term_ Code], 
            T.GlobalDimension1Code AS [Employee_Global Dimension 1 Code], 
            T.GlobalDimension2Code AS [Employee_Global Dimension 2 Code], 
            T.ResourceNo AS [Employee.Resource No_], 
            T.LastDateModified AS [Employee_Last Date Modified], 
            T.Extension AS Employee_Extension, 
            T.Pager AS Employee_Pager, 
            T.FaxNo AS [Employee.Fax No_], 
            T.CompanyEmail AS [Employee_Company E-Mail], 
            T.Title AS Employee_Title, 
            T.SalesPersPurchCode AS [Employee.Salespers__Purch_ Code], 
            T.NoSeries AS [Employee.No_ Series], 
            True AS _from0
        FROM CronusContext.Employee AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for CronusContext.Employee.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView1()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Employee
        [Eventkalender.Database.Employee](T1.Employee_No, T1.Employee_Timestamp, T1.Employee_FirstName, T1.Employee_MiddleName, T1.Employee_LastName, T1.Employee_Initials, T1.Employee_JobTitle, T1.Employee_SearchName, T1.Employee_Address, T1.Employee_Address2, T1.Employee_City, T1.Employee_PostCode, T1.Employee_County, T1.Employee_PhoneNo, T1.Employee_MobilePhoneNo, T1.Employee_Email, T1.Employee_AltAddressCode, T1.Employee_AltAddressStartDate, T1.Employee_AltAddressEndDate, T1.Employee_Picture, T1.Employee_BirthDate, T1.Employee_SocialSecurityNo, T1.Employee_UnionCode, T1.Employee_UnionMembershipNo, T1.Employee_Sex, T1.Employee_CountryRegionCode, T1.Employee_ManagerNo, T1.Employee_EmploymentContractCode, T1.Employee_StatisticsGroupCode, T1.Employee_EmploymentDate, T1.Employee_Status, T1.Employee_InactiveDate, T1.Employee_CauseOfInactivityCode, T1.Employee_TerminationDate, T1.Employee_GroundsForTermCode, T1.Employee_GlobalDimension1Code, T1.Employee_GlobalDimension2Code, T1.Employee_ResourceNo, T1.Employee_LastDateModified, T1.Employee_Extension, T1.Employee_Pager, T1.Employee_FaxNo, T1.Employee_CompanyEmail, T1.Employee_Title, T1.Employee_SalesPersPurchCode, T1.Employee_NoSeries)
    FROM (
        SELECT 
            T.No_ AS Employee_No, 
            T.timestamp AS Employee_Timestamp, 
            T.[First Name] AS Employee_FirstName, 
            T.[Middle Name] AS Employee_MiddleName, 
            T.[Last Name] AS Employee_LastName, 
            T.Initials AS Employee_Initials, 
            T.[Job Title] AS Employee_JobTitle, 
            T.[Search Name] AS Employee_SearchName, 
            T.Address AS Employee_Address, 
            T.[Address 2] AS Employee_Address2, 
            T.City AS Employee_City, 
            T.[Post Code] AS Employee_PostCode, 
            T.County AS Employee_County, 
            T.[Phone No_] AS Employee_PhoneNo, 
            T.[Mobile Phone No_] AS Employee_MobilePhoneNo, 
            T.[E-Mail] AS Employee_Email, 
            T.[Alt_ Address Code] AS Employee_AltAddressCode, 
            T.[Alt_ Address Start Date] AS Employee_AltAddressStartDate, 
            T.[Alt_ Address End Date] AS Employee_AltAddressEndDate, 
            T.Picture AS Employee_Picture, 
            T.[Birth Date] AS Employee_BirthDate, 
            T.[Social Security No_] AS Employee_SocialSecurityNo, 
            T.[Union Code] AS Employee_UnionCode, 
            T.[Union Membership No_] AS Employee_UnionMembershipNo, 
            T.Sex AS Employee_Sex, 
            T.[Country_Region Code] AS Employee_CountryRegionCode, 
            T.[Manager No_] AS Employee_ManagerNo, 
            T.[Emplymt_ Contract Code] AS Employee_EmploymentContractCode, 
            T.[Statistics Group Code] AS Employee_StatisticsGroupCode, 
            T.[Employment Date] AS Employee_EmploymentDate, 
            T.Status AS Employee_Status, 
            T.[Inactive Date] AS Employee_InactiveDate, 
            T.[Cause of Inactivity Code] AS Employee_CauseOfInactivityCode, 
            T.[Termination Date] AS Employee_TerminationDate, 
            T.[Grounds for Term_ Code] AS Employee_GroundsForTermCode, 
            T.[Global Dimension 1 Code] AS Employee_GlobalDimension1Code, 
            T.[Global Dimension 2 Code] AS Employee_GlobalDimension2Code, 
            T.[Resource No_] AS Employee_ResourceNo, 
            T.[Last Date Modified] AS Employee_LastDateModified, 
            T.Extension AS Employee_Extension, 
            T.Pager AS Employee_Pager, 
            T.[Fax No_] AS Employee_FaxNo, 
            T.[Company E-Mail] AS Employee_CompanyEmail, 
            T.Title AS Employee_Title, 
            T.[Salespers__Purch_ Code] AS Employee_SalesPersPurchCode, 
            T.[No_ Series] AS Employee_NoSeries, 
            True AS _from0
        FROM CodeFirstDatabase.Employee AS T
    ) AS T1");
        }
    }
}
