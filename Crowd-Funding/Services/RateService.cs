namespace Crowd_Funding.Services
{
    public class RateService
    {
        private readonly IRateRepository rateRepository;

        public RateService(IRateRepository rateRepository)
        {
            this.rateRepository = rateRepository;
        }

        public async Task<IEnumerable<RateResponseDTO>> GetAllRateAsync()
        {
            var rates = await rateRepository.GetAllAsync();

            return rates.Select(rate => new RateResponseDTO
            {
                Id = rate.Id,
                RateValue = rate.RateValue,
                UserID = rate.UserID,
                ProjectID = rate.ProjectID
            });
        }
        public async Task<RateResponseDTO> GetRateByIdAsync(int id)
        {
            var rate = await rateRepository.GetByIdAsync(id);
            if (rate == null) return null;
            return new RateResponseDTO
            {
                Id = rate.Id,
                RateValue = rate.RateValue,
                UserID = rate.UserID,
                ProjectID = rate.ProjectID
            };
        }
        public async Task<RateResponseDTO> AddRateAsync(AddRateDTO requestRate)
        {
            var rate = new Rate()
            {
                RateValue = requestRate.RateValue,
                ProjectID = requestRate.ProjectID,
                UserID = requestRate.UserID
            };
            await rateRepository.InsertAsync(rate);
            await rateRepository.SaveAsync();
            return new RateResponseDTO
            {
                Id = rate.Id,
                RateValue = rate.RateValue,
                UserID = rate.UserID,
                ProjectID = rate.ProjectID
            };
        }
        public async Task<bool> UpdateRateAsync(UpdateRateDTO requestRate, int id)
        {
            var rate = await rateRepository.GetByIdAsync(id);
            if (rate == null) return false;
            rate.RateValue = requestRate.RateValue ?? rate.RateValue;
            rateRepository.Update(rate);
            await rateRepository.SaveAsync();
            return true;
        }
        public async Task<bool> DeleteRateAsync(int id)
        {
            var rate = await rateRepository.GetByIdAsync(id);
            if (rate == null) return false;
            rateRepository.Delete(rate);
            await rateRepository.SaveAsync();
            return true;
        }
    }
}
