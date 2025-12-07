using HM.DTO;
using System.Collections.Generic;
using System.Linq;

namespace HM.DAO.LINQ
{
    public class RoleDAO
    {
        public List<RoleDTO> GetAllRoles()
        {
            using (var context = new DatabaseContext())
            {
                return context.VaiTros
                    .Where(r => r.TrangThaiXoa != "1")
                    .Select(r => new RoleDTO
                    {
                        MaVT = r.MaVT,
                        TenVT = r.TenVT,
                        TrangThaiXoa = r.TrangThaiXoa
                    })
                    .ToList();
            }
        }

        public int AddRole(RoleDTO role)
        {
            using (var context = new DatabaseContext())
            {
                if (context.VaiTros.Any(r => r.MaVT == role.MaVT))
                {
                    return 0; 
                }
                context.VaiTros.Add(role);
                return context.SaveChanges();
            }
        }

        public int UpdateRole(RoleDTO role)
        {
            using (var context = new DatabaseContext())
            {
                var existingRole = context.VaiTros.FirstOrDefault(r => r.MaVT == role.MaVT);
                if (existingRole == null)
                {
                    return 0;
                }

                existingRole.TenVT = role.TenVT;
                existingRole.TrangThaiXoa = role.TrangThaiXoa;
                return context.SaveChanges();
            }
        }

        public int DeleteRole(string maVT)
        {
            using (var context = new DatabaseContext())
            {
                var role = context.VaiTros.FirstOrDefault(r => r.MaVT == maVT);
                if (role == null)
                {
                    return 0; 
                }

                role.TrangThaiXoa = "1";
                return context.SaveChanges();
            }
        }

        public RoleDTO GetRoleById(string maVT)
        {
            using (var context = new DatabaseContext())
            {
                return context.VaiTros
                    .Where(r => r.MaVT == maVT)
                    .Select(r => new RoleDTO
                    {
                        MaVT = r.MaVT,
                        TenVT = r.TenVT,
                        TrangThaiXoa = r.TrangThaiXoa
                    })
                    .FirstOrDefault();
            }
        }

        public string GetNextRoleId()
        {
            using (var context = new DatabaseContext())
            {
                var lastRole = context.VaiTros
                    .Where(r => r.MaVT.StartsWith("VT"))
                    .OrderByDescending(r => r.MaVT)
                    .FirstOrDefault();

                if (lastRole == null)
                {
                    return "VT000001";
                }

                // Lấy số từ mã (bỏ "VT" đầu)
                var numberStr = lastRole.MaVT.Substring(2);
                if (int.TryParse(numberStr, out int lastNumber))
                {
                    return $"VT{(lastNumber + 1):D6}";
                }

                return "VT000001";
            }
        }

        public List<RoleDTO> SearchRoleByName(string keyword)
        {
            using (var context = new DatabaseContext())
            {
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    return GetAllRoles();
                }

                return context.VaiTros
                    .Where(r => r.TrangThaiXoa != "1" && r.TenVT.Contains(keyword))
                    .Select(r => new RoleDTO
                    {
                        MaVT = r.MaVT,
                        TenVT = r.TenVT,
                        TrangThaiXoa = r.TrangThaiXoa
                    })
                    .ToList();
            }
        }
    }
}