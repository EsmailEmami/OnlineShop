using Microsoft.AspNetCore.DataProtection;
using OnlineShop.Application.Core.Services.PermissionService;
using OnlineShop.Application.Core.Services.RoleService;
using OnlineShop.Application.Core.Services.RoleService.Dtos;
using OnlineShop.Application.Mapping;
using OnlineShop.Data.Core;
using OnlineShop.Data.Core.Repositories;
using OnlineShop.Domain.Entities.Permission;
using System.Xml.Linq;

namespace OnlineShop.Application.Services.RoleService
{
    public class RoleService : ApplicationService<int, Role, RoleInputDto, RoleUpdateDto, RoleOutputDto>, IRoleService
    {
        private readonly IPermissionService _permissionService;
        private readonly IDataProtectionProvider _rootProvider;
        public RoleService(IMapping mapping, IRepository<Role, int> repository, IUnitOfWork unitOfWork, IPermissionService permissionService, IDataProtectionProvider rootProvider) : base(mapping, repository, unitOfWork)
        {
            _permissionService = permissionService;
            _rootProvider = rootProvider;
        }

        public override async Task<RoleOutputDto> GetAsync(int id)
        {
            var role = await _repository.GetAsync(id);

            RoleOutputDto model = new RoleOutputDto()
            {
                Id = role.Id,
                Name = role.Name,
                RoleType = role.RoleType
            };

            var securityTamp = role.SecurityStamp;
            //IEncryptSettingsProvider settings = new EncryptSettingsProvider(_encryptionOptions);
            //var encrypter = new RijndaelStringEncrypter(settings, securityTamp);

            string purpose = "OnlineShop.Application.Services.RoleService";
            IDataProtector protector = _rootProvider.CreateProtector(purpose, securityTamp);

            try
            {
                model.PermissionNames = _permissionService.GetUserPermissionsAsList(XElement.Parse(protector.Unprotect(role.Permissions))).ToArray();
            }
            catch
            {
                //Ignored
            }

            return model;
        }

        public override RoleOutputDto Get(int id)
        {
            var role = _repository.Get(id);

            var model = new RoleOutputDto()
            {
                Id = role.Id,
                Name = role.Name,
                RoleType = role.RoleType
            };

            var securityTamp = role.SecurityStamp;
            //IEncryptSettingsProvider settings = new EncryptSettingsProvider(_encryptionOptions);
            //var encrypter = new RijndaelStringEncrypter(settings, securityTamp);

            string purpose = "OnlineShop.Application.Services.RoleService";
            IDataProtector protector = _rootProvider.CreateProtector(purpose, securityTamp);

            try
            {
                model.PermissionNames = _permissionService.GetUserPermissionsAsList(XElement.Parse(protector.Unprotect(role.Permissions))).ToArray();
            }
            catch
            {
                //Ignored
            }

            return model;
        }

        public override async Task<int> CreateAsync(RoleInputDto inputDto)
        {
            var xmlPermissions = "";

            var role = new Role()
            {
                Name = inputDto.Name,
                RoleType = inputDto.RoleType,
            };

            if (inputDto.PermissionNames == null || inputDto.PermissionNames.Length == 0)
            {
                xmlPermissions = _permissionService.GetPermissionsAsXml("null").ToString();
            }
            else
            {
                xmlPermissions = _permissionService.GetPermissionsAsXml(inputDto.PermissionNames).ToString();
            }

            var securityTamp = Guid.NewGuid().ToString();
            //IEncryptSettingsProvider settings = new EncryptSettingsProvider(_encryptionOptions);
            //var encrypter = new RijndaelStringEncrypter(settings, securityTamp);

            //role.Permissions = encrypter.Encrypt(xmlPermissions);

            string purpose = "OnlineShop.Application.Services.RoleService";
            IDataProtector protector = _rootProvider.CreateProtector(purpose, securityTamp);
            role.Permissions = protector.Protect(xmlPermissions);
            role.SecurityStamp = securityTamp;
            await _repository.InsertAsync(role);

            _unitOfWork.SaveAllChanges();

            //encrypter.Dispose();

            return role.Id;
        }

        public override async Task UpdateAsync(int id, RoleUpdateDto inputDto)
        {
            var role = await _repository.GetAsync(id);

            var securityTamp = role.SecurityStamp;
            //IEncryptSettingsProvider settings = new EncryptSettingsProvider(_encryptionOptions);
            //var encrypter = new RijndaelStringEncrypter(settings, securityTamp);

            string purpose = "OnlineShop.Application.Services.RoleService";
            IDataProtector protector = _rootProvider.CreateProtector(purpose, securityTamp);

            role.Name = inputDto.Name;
            role.RoleType = inputDto.RoleType;

            if (inputDto.PermissionNames == null || inputDto.PermissionNames.Length == 1)
                role.Permissions = protector.Protect(_permissionService.GetPermissionsAsXml(string.Empty).ToString());
            else
                role.Permissions = protector.Protect(_permissionService.GetPermissionsAsXml(inputDto.PermissionNames).ToString());

            await _repository.UpdateAsync(role);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
