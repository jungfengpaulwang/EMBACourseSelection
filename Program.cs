using FISCA;
using FISCA.Permission;
using K12.Presentation;
using CourseSelection.DetailItems;
using FISCA.Presentation;
using FISCA.UDT;

namespace CourseSelection
{
    /// <summary>
    /// 自訂資料欄位
    /// </summary>
    public class Program
    {
        [MainMethod("CourseSelection")]
        public static void Main()
        {
            SyncDBSchema();
            InitDetailContent();
        }

        public static void SyncDBSchema()
        {
            #region 模組啟用先同步Schmea

            SchemaManager Manager = new SchemaManager(FISCA.Authentication.DSAServices.DefaultConnection);

            Manager.SyncSchema(new UDT.CSAttend());
            Manager.SyncSchema(new UDT.CSAttendLog());
            Manager.SyncSchema(new UDT.CSAttendSnapshot());
            Manager.SyncSchema(new UDT.CSCourseExt());
            Manager.SyncSchema(new UDT.CSFaq());
            Manager.SyncSchema(new UDT.CSOpeningInfo());
            Manager.SyncSchema(new UDT.RegistrationConfirm());
            Manager.SyncSchema(new UDT.CSConfiguration());
            Manager.SyncSchema(new UDT.TeacherExtVO());
            Manager.SyncSchema(new UDT.WebEMailAccount());
            Manager.SyncSchema(new UDT.ConflictCourse());
            Manager.SyncSchema(new UDT.SCAttendExt());
            Manager.SyncSchema(new UDT.WebUrls());

            if (!FISCA.RTContext.IsDiagMode)
                ServerModule.AutoManaged("https://module.ischool.com.tw/module/140/NTU_EMBA_CourseSelection/udm.xml");            

            #endregion
        }

        public static void InitDetailContent()
        {
            #region 資料項目

            /*  註冊權限  */

            Catalog detail = RoleAclSource.Instance["課程"]["資料項目"];

            detail.Add(new DetailItemFeature(typeof(Course_CSIdentity)));

            if (UserAcl.Current[typeof(Course_CSIdentity)].Viewable)
                NLDPanels.Course.AddDetailBulider<Course_CSIdentity>();

            detail = RoleAclSource.Instance["學生"]["資料項目"];

            detail.Add(new DetailItemFeature(typeof(CSSnapshot)));

            if (UserAcl.Current[typeof(CSSnapshot)].Viewable)
                NLDPanels.Student.AddDetailBulider<CSSnapshot>();

            #endregion

            #region 課程>選課>設定>選課開放時間
            Catalog button_OpeningInfoSetting = RoleAclSource.Instance["課程"]["功能按鈕"];
            button_OpeningInfoSetting.Add(new RibbonFeature("Button_OpeningInfoSetting", "設定選課開放時間"));

            var templateManager = MotherForm.RibbonBarItems["課程", "選課"]["設定"];
            templateManager.Size = RibbonBarButton.MenuButtonSize.Large;
            templateManager.Image = Properties.Resources.sandglass_unlock_64;
            templateManager["選課開放時間設定"].Enable = UserAcl.Current["Button_OpeningInfoSetting"].Executable;
            templateManager["選課開放時間設定"].Click += delegate
            {
                (new Forms.frmOpeningInfo()).ShowDialog();
            };
            #endregion

            #region 課程>選課>設定>衝堂與限制複選課程設定
            RoleAclSource.Instance["課程"]["功能按鈕"].Add(new RibbonFeature("Button_ChongTongCourseChecking", "設定衝堂與限制複選課程"));

            templateManager = MotherForm.RibbonBarItems["課程", "選課"]["設定"];
            //templateManager.Size = RibbonBarButton.MenuButtonSize.Large;
            //templateManager.Image = Properties.Resources.foreign_key_lock_64;
            templateManager["衝堂與限制複選課程"].Enable = UserAcl.Current["Button_ChongTongCourseChecking"].Executable;
            templateManager["衝堂與限制複選課程"].Click += delegate
            {
                (new Forms.ConflictCourseManagement()).ShowDialog();
            };
            #endregion

            #region 課程>選課>設定>課程計劃
            RoleAclSource.Instance["課程"]["功能按鈕"].Add(new RibbonFeature("Button_CoursePlanUrlSetting", "設定課程計劃"));

            templateManager = MotherForm.RibbonBarItems["課程", "選課"]["設定"];
            //templateManager.Size = RibbonBarButton.MenuButtonSize.Large;
            //templateManager.Image = Properties.Resources.foreign_key_lock_64;
            templateManager["課程計劃"].Enable = UserAcl.Current["Button_CoursePlanUrlSetting"].Executable;
            templateManager["課程計劃"].Click += delegate
            {
                (new Forms.frmCoursePlanUrl()).ShowDialog();
            };
            #endregion

            #region 課程>選課>選課學生調整
            RoleAclSource.Instance["課程"]["功能按鈕"].Add(new RibbonFeature("Button_AttendFilter", "調整選課學生"));

            //templateManager = MotherForm.RibbonBarItems["課程", "選課"];
            //templateManager.Size = RibbonBarButton.MenuButtonSize.Large;
            //templateManager.Image = Properties.Resources.foreign_key_lock_64;
            MotherForm.RibbonBarItems["課程", "選課"]["選課學生調整"].Enable = UserAcl.Current["Button_AttendFilter"].Executable;
            MotherForm.RibbonBarItems["課程", "選課"]["選課學生調整"].Click += delegate
            {
                (new Forms.frmFilter()).ShowDialog();
            };
            #endregion

            #region 課程>選課>選課注意事項及問答管理
            RoleAclSource.Instance["課程"]["功能按鈕"].Add(new RibbonFeature("Button_CSFaq", "管理選課注意事項及問答"));

            //templateManager = MotherForm.RibbonBarItems["課程", "選課"];
            //templateManager.Size = RibbonBarButton.MenuButtonSize.Large;
            //templateManager.Image = Properties.Resources.foreign_key_lock_64;
            MotherForm.RibbonBarItems["課程", "選課"]["選課注意事項及問答管理"].Enable = UserAcl.Current["Button_CSFaq"].Executable;
            MotherForm.RibbonBarItems["課程", "選課"]["選課注意事項及問答管理"].Click += delegate
            {
                (new Forms.frmFAQ()).ShowDialog();
            };
            #endregion

            #region 課程>選課>備份選課結果
            RoleAclSource.Instance["課程"]["功能按鈕"].Add(new RibbonFeature("Button_CSAttendToSnapshot", "備份選課結果"));

            //templateManager = MotherForm.RibbonBarItems["課程", "選課"];
            //templateManager.Size = RibbonBarButton.MenuButtonSize.Large;
            //templateManager.Image = Properties.Resources.foreign_key_lock_64;
            MotherForm.RibbonBarItems["課程", "選課"]["備份選課結果"].Enable = UserAcl.Current["Button_CSAttendToSnapshot"].Executable;
            MotherForm.RibbonBarItems["課程", "選課"]["備份選課結果"].Click += delegate
            {
                (new Forms.frmCSAttendToSnapshot()).ShowDialog();
            };
            #endregion

            #region 課程>選課>確認並發佈選課結果
            RoleAclSource.Instance["課程"]["功能按鈕"].Add(new RibbonFeature("Button_CSAttendToCourseExt", "確認並發佈選課結果"));

            //templateManager = MotherForm.RibbonBarItems["課程", "選課"];
            //templateManager.Size = RibbonBarButton.MenuButtonSize.Large;
            //templateManager.Image = Properties.Resources.foreign_key_lock_64;
            MotherForm.RibbonBarItems["課程", "選課"]["確認並發佈選課結果"].Enable = UserAcl.Current["Button_CSAttendToCourseExt"].Executable;
            MotherForm.RibbonBarItems["課程", "選課"]["確認並發佈選課結果"].Click += delegate
            {
                (new Forms.frmCSAttendToCourseExt()).ShowDialog();
            };
            #endregion

            #region 課程>選課>查詢>選課結果
            RoleAclSource.Instance["課程"]["功能按鈕"].Add(new RibbonFeature("Button_CSAttend_Query", "查詢選課結果"));

            MotherForm.RibbonBarItems["課程", "選課"]["查詢"].Size = RibbonBarButton.MenuButtonSize.Large;
            MotherForm.RibbonBarItems["課程", "選課"]["查詢"].Image = Properties.Resources.searchHistory;
            MotherForm.RibbonBarItems["課程", "選課"]["查詢"]["選課結果"].Enable = UserAcl.Current["Button_CSAttend_Query"].Executable;
            MotherForm.RibbonBarItems["課程", "選課"]["查詢"]["選課結果"].Click += delegate
            {
                (new Forms.frmAttend_Course()).ShowDialog();
            };
            #endregion

            #region 課程>選課>查詢>加退選確認
            RoleAclSource.Instance["課程"]["功能按鈕"].Add(new RibbonFeature("Button_CSAttendNoChange", "查詢加退選確認"));

            MotherForm.RibbonBarItems["課程", "選課"]["查詢"]["加退選確認"].Enable = UserAcl.Current["Button_CSAttendNoChange"].Executable;
            MotherForm.RibbonBarItems["課程", "選課"]["查詢"]["加退選確認"].Click += delegate
            {
                (new Forms.frmAttendNoChange()).ShowDialog();
            };
            #endregion            

            #region 課程>選課>匯出>選上學生
            RoleAclSource.Instance["課程"]["功能按鈕"].Add(new RibbonFeature("Button_CSAttend_Export", "匯出選上學生"));

            MotherForm.RibbonBarItems["課程", "選課"]["匯出"].Size = RibbonBarButton.MenuButtonSize.Large;
            MotherForm.RibbonBarItems["課程", "選課"]["匯出"].Image = Properties.Resources.Export_Image;
            MotherForm.RibbonBarItems["課程", "選課"]["匯出"]["選上學生"].Enable = UserAcl.Current["Button_CSAttend_Export"].Executable;
            MotherForm.RibbonBarItems["課程", "選課"]["匯出"]["選上學生"].Click += delegate
            {
                (new Export.CSAttend()).ShowDialog();
            };
            #endregion

            #region 課程>選課>匯出>未選上學生
            RoleAclSource.Instance["課程"]["功能按鈕"].Add(new RibbonFeature("Button_CSAttendLog_Export", "匯出未選上學生"));

            //MotherForm.RibbonBarItems["課程", "選課"]["匯出"].Size = RibbonBarButton.MenuButtonSize.Large;
            //MotherForm.RibbonBarItems["課程", "選課"]["匯出"].Image = Properties.Resources.Export_Image;
            MotherForm.RibbonBarItems["課程", "選課"]["匯出"]["未選上學生"].Enable = UserAcl.Current["Button_CSAttendLog_Export"].Executable;
            MotherForm.RibbonBarItems["課程", "選課"]["匯出"]["未選上學生"].Click += delegate
            {
                (new Export.CSAttendLog()).ShowDialog();
            };
            #endregion

            #region 課程>選課>匯出>未確認加退選學生
            RoleAclSource.Instance["課程"]["功能按鈕"].Add(new RibbonFeature("Button_CSNoConfirm_Export", "匯出未確認加退選學生"));

            //MotherForm.RibbonBarItems["課程", "選課"]["匯出"].Size = RibbonBarButton.MenuButtonSize.Large;
            //MotherForm.RibbonBarItems["課程", "選課"]["匯出"].Image = Properties.Resources.Export_Image;
            MotherForm.RibbonBarItems["課程", "選課"]["匯出"]["未確認加退選學生"].Enable = UserAcl.Current["Button_CSNoConfirm_Export"].Executable;
            MotherForm.RibbonBarItems["課程", "選課"]["匯出"]["未確認加退選學生"].Click += delegate
            {
                (new Export.CSNoConfirm()).ShowDialog();
            };
            #endregion
            
            #region 課程>選課>匯入>選課記錄

            MotherForm.RibbonBarItems["課程", "選課"]["匯入"].Image = Properties.Resources.Import_Image;
            MotherForm.RibbonBarItems["課程", "選課"]["匯入"].Size = RibbonBarButton.MenuButtonSize.Large;

            Catalog button_importStudent = RoleAclSource.Instance["課程"]["功能按鈕"];
            button_importStudent.Add(new RibbonFeature("Course_Button_Import_CSAttend", "匯入選課記錄"));
            MotherForm.RibbonBarItems["課程", "選課"]["匯入"]["選課記錄"].Enable = UserAcl.Current["Course_Button_Import_CSAttend"].Executable;

            MotherForm.RibbonBarItems["課程", "選課"]["匯入"]["選課記錄"].Click += delegate
            {
                new Import.CSAttend_Import().Execute();
            };

            #endregion

            #region 課程>選課>設定>樣版設定>選課最終確認說明文字
            RoleAclSource.Instance["課程"]["功能按鈕"].Add(new RibbonFeature("Button_CSTemplate_cs_final_message", "設定選課最終確認說明文字樣版"));

            templateManager = MotherForm.RibbonBarItems["課程", "選課"]["設定"];
            //templateManager.Size = RibbonBarButton.MenuButtonSize.Large;
            //templateManager.Image = Properties.Resources.foreign_key_lock_64;
            templateManager["樣版設定"]["選課最終確認說明文字"].Enable = UserAcl.Current["Button_CSTemplate_cs_final_message"].Executable;
            templateManager["樣版設定"]["選課最終確認說明文字"].Click += delegate
            {
                (new Forms.Email_Content_Template(UDT.CSConfiguration.TemplateName.選課最終確認說明文字)).ShowDialog();
            };
            #endregion

            #region 課程>選課>設定>樣版設定>第一階段選課結果email通知
            RoleAclSource.Instance["課程"]["功能按鈕"].Add(new RibbonFeature("Button_CSTemplate_email_content1_template", "設定第一階段選課結果email通知樣版"));

            templateManager = MotherForm.RibbonBarItems["課程", "選課"]["設定"];
            //templateManager.Size = RibbonBarButton.MenuButtonSize.Large;
            //templateManager.Image = Properties.Resources.foreign_key_lock_64;
            templateManager["樣版設定"]["第一階段選課結果email通知"].Enable = UserAcl.Current["Button_CSTemplate_email_content1_template"].Executable;
            templateManager["樣版設定"]["第一階段選課結果email通知"].Click += delegate
            {
                (new Forms.Email_Content_Template(UDT.CSConfiguration.TemplateName.第一階段選課結果email通知)).ShowDialog();
            };
            #endregion

            #region 課程>選課>設定>樣版設定>第二階段選課結果email通知
            RoleAclSource.Instance["課程"]["功能按鈕"].Add(new RibbonFeature("Button_CSTemplate_email_content2_template", "設定第二階段選課結果email通知樣版"));

            templateManager = MotherForm.RibbonBarItems["課程", "選課"]["設定"];
            //templateManager.Size = RibbonBarButton.MenuButtonSize.Large;
            //templateManager.Image = Properties.Resources.foreign_key_lock_64;
            templateManager["樣版設定"]["第二階段選課結果email通知"].Enable = UserAcl.Current["Button_CSTemplate_email_content2_template"].Executable;
            templateManager["樣版設定"]["第二階段選課結果email通知"].Click += delegate
            {
                (new Forms.Email_Content_Template(UDT.CSConfiguration.TemplateName.第二階段選課結果email通知)).ShowDialog();
            };
            #endregion

            #region 課程>選課>設定>樣版設定>第一階段退選提醒文字
            RoleAclSource.Instance["課程"]["功能按鈕"].Add(new RibbonFeature("Button_CSTemplate_cs_cancel1_content_template", "設定第一階段退選提醒文字樣版"));

            templateManager = MotherForm.RibbonBarItems["課程", "選課"]["設定"];
            //templateManager.Size = RibbonBarButton.MenuButtonSize.Large;
            //templateManager.Image = Properties.Resources.foreign_key_lock_64;
            templateManager["樣版設定"]["第一階段退選提醒文字"].Enable = UserAcl.Current["Button_CSTemplate_cs_cancel1_content_template"].Executable;
            templateManager["樣版設定"]["第一階段退選提醒文字"].Click += delegate
            {
                (new Forms.Email_Content_Template(UDT.CSConfiguration.TemplateName.第一階段退選提醒文字)).ShowDialog();
            };
            #endregion

            #region 課程>選課>設定>樣版設定>第二階段退選提醒文字
            RoleAclSource.Instance["課程"]["功能按鈕"].Add(new RibbonFeature("Button_CSTemplate_cs_cancel2_content_template", "設定第二階段退選提醒文字樣版"));

            templateManager = MotherForm.RibbonBarItems["課程", "選課"]["設定"];
            //templateManager.Size = RibbonBarButton.MenuButtonSize.Large;
            //templateManager.Image = Properties.Resources.foreign_key_lock_64;
            templateManager["樣版設定"]["第二階段退選提醒文字"].Enable = UserAcl.Current["Button_CSTemplate_cs_cancel2_content_template"].Executable;
            templateManager["樣版設定"]["第二階段退選提醒文字"].Click += delegate
            {
                (new Forms.Email_Content_Template(UDT.CSConfiguration.TemplateName.第二階段退選提醒文字)).ShowDialog();
            };
            #endregion
            
            #region 課程>選課>設定>WEB端寄發電子郵件帳號
            RoleAclSource.Instance["課程"]["功能按鈕"].Add(new RibbonFeature("Button_WEB_Email_Credential", "設定WEB端寄發電子郵件帳號"));

            templateManager = MotherForm.RibbonBarItems["課程", "選課"]["設定"];
            //templateManager.Size = RibbonBarButton.MenuButtonSize.Large;
            //templateManager.Image = Properties.Resources.foreign_key_lock_64;
            templateManager["WEB端寄發電子郵件帳號"].Enable = UserAcl.Current["Button_WEB_Email_Credential"].Executable;
            templateManager["WEB端寄發電子郵件帳號"].Click += delegate
            {
                (new Forms.Email_Credential()).ShowDialog();
            };
            #endregion
            
            //templateManager = MotherForm.RibbonBarItems["課程", "選課"]["檢查"];
            //templateManager["錯誤選課學生"].Click += delegate
            //{
            //    (new Forms.Form1()).ShowDialog();
            //};
        }
    }
}
