using Crowd_Funding.DTO;
using Crowd_Funding.Repositories.Generic;

namespace Crowd_Funding.Services
{
    public class DonationService
    {
        private readonly IGenericRepository<Donation> donationRepository;

        public DonationService(IDonationRepository donationRepository)
        {
            this.donationRepository = donationRepository;
        }

        public async Task<IEnumerable<DonationResponseDTO>> GetAllDonationAsync()
        {
            var donations = await donationRepository.GetAllAsync();

            return donations.Select(d => new DonationResponseDTO
            {
                Id = d.Id,
                Amount = d.Amount,
                Date = d.Date,
                Status = d.Status,
                UserID = d.UserID,
                ProjectID = d.ProjectID,
            });
        }

        public async Task<DonationResponseDTO> GetDonationByIDAsync(int id)
        {
            var donation = await donationRepository.GetByIdAsync(id);
            if (donation == null) return null;

            return new DonationResponseDTO
            {
                Id = donation.Id,
                Amount = donation.Amount,
                Date = donation.Date,
                Status = donation.Status,
                UserID = donation.UserID,
                ProjectID = donation.ProjectID,
            };
        }

        public async Task<DonationResponseDTO> AddDonationAsync(AddDonationDTO requestDonation)
        {
            var donation = new Donation()
            {
                Amount = requestDonation.Amount,
                Status = requestDonation.Status,
                Date = DateTime.Now,
                ProjectID = requestDonation.ProjectID,
                UserID = requestDonation.UserID
            };
            await donationRepository.InsertAsync(donation);
            await donationRepository.SaveAsync();
            return new DonationResponseDTO
            {
                Id = donation.Id,
                Amount = donation.Amount,
                Date = donation.Date,
                Status = donation.Status,
                UserID = donation.UserID,
                ProjectID = donation.ProjectID,
            };
        }

        public async Task<bool> UpdateDonationAsync(UpdateDonationDTO requestDonation, int id)
        {
            var DBDonation = await donationRepository.GetByIdAsync(id);
            if (DBDonation == null) return false;
            DBDonation.Amount = requestDonation.Amount ?? DBDonation.Amount;
            DBDonation.Status = requestDonation.Status ?? DBDonation.Status;

            donationRepository.Update(DBDonation);
            await donationRepository.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteDonationAsync(int id)
        {
            var DBDonation = await donationRepository.GetByIdAsync(id);
            if (DBDonation == null) return false;
            donationRepository.Delete(DBDonation);
            await donationRepository.SaveAsync();
            return true;
        }
    }
}
