/*
Mã sinh viên: 202418946
Họ tên: Phạm Văn Minh
*/

using Bai03.Models;

// 1. Tạo hai Employee bằng hai constructor khác nhau. 
Console.WriteLine("TestCase 1");
Employee employee1 = new("E01", "Minh");
Employee employee2 = new("E02", "Nam", 1000);
// 2. Tạo hai SoftwareEngineer bằng hai constructor khác nhau. 
Console.WriteLine("TestCase 2");
SoftwareEngineer softwareEngineer1 = new("SE01", "Nguyen", "C#");
SoftwareEngineer softwareEngineer2 = new("SE02", "An", 2000, "Java", 500);
// 3. Tăng lương một nhân sự bằng số tiền cố định. 
Console.WriteLine("TestCase 3");
employee1.IncreaseSalary(300);
// 4. Tăng lương một nhân sự khác theo phần trăm. 
Console.WriteLine("TestCase 4");
employee2.IncreaseSalary(10, true);
// 5. Tạo nhóm dự án không có trưởng nhóm. 
Console.WriteLine("TestCase 5");
ProjectTeam projectTeam1 = new("P01", "Project 1");
// 6. Thêm một nhân sự vào nhóm bằng addMember(employee).
Console.WriteLine("TestCase 6");
projectTeam1.AddMember(employee1);
// 7. Thêm một kỹ sư bằng addMember(employee, true) để đặt làm trưởng nhóm.
Console.WriteLine("TestCase 7");
projectTeam1.AddMember(softwareEngineer1, true);
// 8. Thử thêm lại một thành viên đã tồn tại.
Console.WriteLine("TestCase 8");
projectTeam1.AddMember(employee1);
// 9. Hiển thị danh sách bằng lời gọi đa hình. 
Console.WriteLine("TestCase 9");
projectTeam1.DisplayTeam();
// 10. Tính tổng chi phí nhân sự hằng tháng.
Console.WriteLine("TestCase 10");
softwareEngineer1.IncreaseSalary(200);
projectTeam1.CalculateTotalMonthlyCost();
// 11. Thử xóa trưởng nhóm hiện tại và kiểm tra thao tác bị từ chối.
Console.WriteLine("TestCase 11");
projectTeam1.RemoveMember(softwareEngineer1.Id);
// 12. Đổi trưởng nhóm rồi xóa người từng là trưởng nhóm.
Console.WriteLine("TestCase 12");
projectTeam1.ChangeLeader(employee1);
projectTeam1.RemoveMember(softwareEngineer1.Id);
// 13. Tạo một nhóm thứ hai và thêm một nhân sự đã có ở nhóm thứ nhất để chứng minh
// quan hệ kết tập nhiều nhóm.
Console.WriteLine("TestCase 13");
ProjectTeam projectTeam2 = new("P02", "Project 2");
projectTeam2.AddMember(employee1);
// 14. Hủy nhóm thứ hai bằng cách kết thúc một khối lệnh cục bộ.
Console.WriteLine("TestCase 14");
{
    ProjectTeam projectTeam2Local = new("P02", "Project 2");
    projectTeam2Local.AddMember(employee1);
    projectTeam2Local.DisplayTeam();
}
GC.Collect();
GC.WaitForPendingFinalizers();
// 15. Chứng minh nhân sự của nhóm thứ hai vẫn tồn tại sau khi nhóm bị hủy. 
Console.WriteLine("TestCase 15");
Console.WriteLine($"Trạng thái employee1 ngoài scope: {employee1.FullName} (ID: {employee1.Id}).");



