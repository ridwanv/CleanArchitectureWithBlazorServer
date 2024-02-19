using Blazor.Server.UI.Models.SideMenu;
using CleanArchitecture.Blazor.Infrastructure.Constants.Role;
using MudBlazor;

namespace Blazor.Server.UI.Services.Navigation;

public class MenuService : IMenuService
{
    private readonly List<MenuSectionModel> _features = new List<MenuSectionModel>()
    {
        new MenuSectionModel
        {
            Title = "Application",
            Roles=new string[]{ RoleConstants.AdministratorRole },
            SectionItems = new List<MenuSectionItemModel>
            {
                new()
                {
                    Title = "Home",
                    Icon = Icons.Material.Filled.Home,
                    Href = "/"
                },
                //new()
                //{
                //    Title = "E-Commerce",
                //    Icon = Icons.Material.Filled.ShoppingCart,
                //    PageStatus = PageStatus.Completed,
                //    IsParent = true,
                //    MenuItems = new List<MenuSectionSubItemModel>
                //    {
                //        new(){
                //             Title = "Products",
                //             Href = "/pages/products",
                //             PageStatus = PageStatus.Completed,
                //        },
                //        new(){
                //             Title = "Documents",
                //             Href = "/pages/documents",
                //             PageStatus = PageStatus.Completed,
                //        }
                //    }
                //},
                new()
                {
                    IsParent = true,
                    Title = "Supplier Management",
                    Icon = Icons.Material.Filled.LocationCity,
                    MenuItems = new List<MenuSectionSubItemModel>
                    {
                        new()
                        {
                            Title = "Suppliers",
                            Href = "/suppliers/index",
                            PageStatus = PageStatus.Completed
                        }
                    }
                },
               new()
                {
                    IsParent = true,
                    Title = "Project Procurement",
                    Icon = Icons.Material.Filled.LocationCity,
                    MenuItems = new List<MenuSectionSubItemModel>
                    {
                        new()
                        {
                            Title = "Projects",
                            Href = "/projects/index",
                            PageStatus = PageStatus.Completed
                        }
                    }
                },
                              new()
                {
                    IsParent = true,
                    Title = "Configuration",
                    Icon = Icons.Material.Filled.LocationCity,
                    MenuItems = new List<MenuSectionSubItemModel>
                    {
                        new()
                        {
                            Title = "Questionaires",
                            Href = "/questionaire/index",
                            PageStatus = PageStatus.Completed
                        }
                    }
                }
                //new()
                //{
                //    Title = "Analytics",
                //    Roles=new string[]{ RoleConstants.AdministratorRole, RoleConstants.UsersRole },
                //    Icon = Icons.Material.Filled.Analytics,
                //    Href = "/analytics",
                //    PageStatus = PageStatus.ComingSoon
                //},
                //new()
                //{
                //    Title = "Banking",
                //    Roles=new string[]{ RoleConstants.AdministratorRole,RoleConstants.UsersRole },
                //    Icon = Icons.Material.Filled.Money,
                //    Href = "/banking",
                //    PageStatus = PageStatus.ComingSoon
                //},
                //new()
                //{
                //    Title = "Booking",
                //    Roles=new string[]{ RoleConstants.AdministratorRole,RoleConstants.UsersRole },
                //    Icon = Icons.Material.Filled.CalendarToday,
                //    Href = "/booking",
                //    PageStatus = PageStatus.ComingSoon
                //}
            }
        },

        new MenuSectionModel
        {
            Title = "MANAGEMENT",
            Roles=new string[]{ RoleConstants.AdministratorRole },
            SectionItems = new List<MenuSectionItemModel>
            {
                new()
                {
                    IsParent = true,
                    Title = "Authorization",
                    Icon = Icons.Material.Filled.ManageAccounts,
                    MenuItems = new List<MenuSectionSubItemModel>
                    {
                        new()
                        {
                            Title = "Multi-Tenant",
                            Href = "/system/tenants",
                            PageStatus = PageStatus.Completed
                        },
                        new()
                        {
                            Title = "Users",
                            Href = "/identity/users",
                            PageStatus = PageStatus.Completed
                        },
                        new()
                        {
                            Title = "Roles",
                            Href = "/identity/roles",
                            PageStatus = PageStatus.Completed
                        },
                        new()
                        {
                            Title = "Profile",
                            Href = "/user/profile",
                            PageStatus = PageStatus.Completed
                        }
                    }
                },
                new()
                {
                    IsParent = true,
                    Title = "System",
                    Icon = Icons.Material.Filled.Devices,
                    MenuItems = new List<MenuSectionSubItemModel>
                    {   new()
                        {
                            Title = "Picklist",
                            Href = "/system/picklist",
                            PageStatus = PageStatus.Completed
                        },
                        new()
                        {
                            Title = "Audit Trails",
                            Href = "/system/audittrails",
                            PageStatus = PageStatus.Completed
                        },
                        new()
                        {
                            Title = "Log",
                            Href = "/system/logs",
                            PageStatus = PageStatus.Completed
                        },
                        new()
                        {
                            Title = "Jobs",
                            Href = "/jobs",
                            PageStatus = PageStatus.ComingSoon,
                            Target="_blank"

                        }
                    }
                }

            }
        },

       new MenuSectionModel
        {
            Title = "SUPPLIER",
            Roles=new string[]{ RoleConstants.Supplier },
            SectionItems = new List<MenuSectionItemModel>
            {
                new()
                {
                    IsParent = true,
                    Title = "Events",
                    Icon = Icons.Material.Filled.Devices,
                    MenuItems = new List<MenuSectionSubItemModel>
                    {   new()
                        {
                            Title = "Invitations",
                            Href = "/system/picklist",
                            PageStatus = PageStatus.Completed
                        }
                    }
                },
                new()
                {
                    IsParent = true,
                    Title = "Request For Information",
                    Icon = Icons.Material.Filled.Devices,
                    MenuItems = new List<MenuSectionSubItemModel>
                    {   new()
                        {
                            Title = "Information Requests",
                            Href = "/system/picklist",
                            PageStatus = PageStatus.Completed
                        }
                    }
                }

            }
        }
    };

    public IEnumerable<MenuSectionModel> Features => _features;
}
