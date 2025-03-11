namespace Crowd_Funding.Services
{
    public class ReportService
    {
        private readonly IReportRepository reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            this.reportRepository = reportRepository;
        }
        public async Task<IEnumerable<ReportResponseDTO>> GetAllReportAsync()
        {
            var reports = await reportRepository.GetAllAsync();

            return reports.Select(report => new ReportResponseDTO
            {
                Id = report.Id,
                CreatedAt = report.CreatedAt,
                Content = report.Content,
                UserID = report.UserID,
                ProjectID = report.ProjectID
            });
        }
        public async Task<ReportResponseDTO> GetReportByIdAsync(int id)
        {
            var report = await reportRepository.GetByIdAsync(id);
            if (report == null) return null;
            return new ReportResponseDTO
            {
                Id = report.Id,
                CreatedAt = report.CreatedAt,
                Content = report.Content,
                UserID = report.UserID,
                ProjectID = report.ProjectID
            };
        }
        public async Task<ReportResponseDTO> AddReportAsync(AddReportDTO requestReport)
        {
            var report = new Report()
            {
                Content = requestReport.Content,
                CreatedAt = DateTime.Now,
                ProjectID = requestReport.ProjectID,
                UserID = requestReport.UserID
            };
            await reportRepository.InsertAsync(report);
            await reportRepository.SaveAsync();
            return new ReportResponseDTO
            {
                Id = report.Id,
                CreatedAt = report.CreatedAt,
                Content = report.Content,
                UserID = report.UserID,
                ProjectID = report.ProjectID
            };
        }
        public async Task<bool> UpdateReportAsync(UpdateReportDTO requestReport, int id)
        {
            var report = await reportRepository.GetByIdAsync(id);
            if (report == null) return false;
            report.Content = requestReport.Content ?? report.Content;
            reportRepository.Update(report);
            await reportRepository.SaveAsync();
            return true;
        }
        public async Task<bool> DeleteReportAsync(int id)
        {
            var report = await reportRepository.GetByIdAsync(id);
            if (report == null) return false;
            reportRepository.Delete(report);
            await reportRepository.SaveAsync();
            return true;
        }
    }
}
