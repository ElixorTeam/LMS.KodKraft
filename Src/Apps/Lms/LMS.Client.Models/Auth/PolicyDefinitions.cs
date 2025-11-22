namespace LMS.Client.Models.Auth;

public static class Policy
{
    public const string Admin = nameof(Admin);
    public const string Pupil = nameof(Pupil);
    public const string Parent = nameof(Parent);
    public const string Teacher = nameof(Teacher);
}

public static class Role
{
    public const string Admin = "kk-lms-admin";
    public const string Pupil = "kk-lms-pupil";
    public const string Parent = "kk-lms-parent";
    public const string Teacher = "kk-lms-teacher";
}