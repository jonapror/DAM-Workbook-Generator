using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using Aprimo.ConfigurationWorkbookGenerator.Helpers;
using RestSharp;

namespace Aprimo.ConfigurationWorkbookGenerator
{
    internal class WorkbookHelper
    {
        private readonly Guid EnglishLanguageId = new Guid("c2bd4f9b-bb95-4bcb-80c3-1e924c9c26dc");
        private Dictionary<Guid, dynamic> FieldGroups = null;
        private Dictionary<Guid, dynamic> FieldDefinitions = null;
        private Dictionary<Guid, dynamic> UserGroups = null;
        private readonly Dictionary<string, dynamic> RolePermissions = new Dictionary<string, dynamic>();
        private Dictionary<Guid, dynamic> Watermarks = null;
        private Dictionary<Guid, dynamic> Classifications = null;
        private Dictionary<Guid, dynamic> Translations = null;
        private Dictionary<Guid, dynamic> Rules = null;
        private Dictionary<Guid, dynamic> ContentTypes = null;

        public string Token;

        private readonly string SubDomain;
        private readonly string ClientId;
        private readonly string UserName;
        private readonly string UserToken;
        private readonly string AprimoMoUrl;
        private readonly string AprimoDamUrl;
        private static AccessHelper accessHelper; 

        private readonly UiHelper UiHelper;

        public WorkbookHelper(string subDomain, string clientId, string userName, string userToken, UiHelper uiHelper)
        {
            this.SubDomain = subDomain;
            this.ClientId = clientId;
            this.UserName = userName;
            this.UserToken = userToken;
            this.UiHelper = uiHelper;

            AprimoMoUrl = string.Format(@"https://{0}.aprimo.com/api", subDomain);
            AprimoDamUrl = string.Format(@"https://{0}.dam.aprimo.com/api/core", subDomain);

            accessHelper = new AccessHelper(userName, userToken, AprimoMoUrl, clientId);
        }

        internal void ExportConfiguration(string outputPath, string pathToFileWithNotes)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            ExcelPackage excelPackage = null;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excelPackageWithNotes = new ExcelPackage();

            try
            {
                this.UiHelper.LogInfo("Preloading data...");
                PreloadData();

                excelPackage = new ExcelPackage(new FileInfo(outputPath));

                if (pathToFileWithNotes.Length > 0)
                {
                    FileInfo fileWitNotes = new FileInfo(pathToFileWithNotes);
                    if (fileWitNotes.Exists)
                    {
                        excelPackageWithNotes = new ExcelPackage(fileWitNotes);
                    }
                }

                string worksheetName = "";

                //Cover sheet
                this.UiHelper.SetMainProcessProgressBarMaximum(12);
                this.UiHelper.LogInfo("Creating cover sheet...", true);
                ExcelWorksheet coverSheet = excelPackage.Workbook.Worksheets.Add("Cover Sheet");
                coverSheet.Cells[1, 1].Value = "Configuration Workbook";
                coverSheet.Cells[2, 1].Value = "Environment";
                coverSheet.Cells[2, 2].Value = this.SubDomain;
                coverSheet.Cells[3, 1].Value = "User Account Used";
                coverSheet.Cells[3, 2].Value = this.UserName;
                coverSheet.Cells[4, 1].Value = "Generated On";
                coverSheet.Cells[4, 2].Value = DateTime.Now;
                coverSheet.Cells[4, 2].Style.Numberformat.Format = "dd/mm/yyyy HH:mm:ss";

                //Export usergroups
                worksheetName = "User Groups";
                this.UiHelper.LogInfo(string.Format("Creating {0} sheet...", worksheetName), true);
                ExcelWorksheet userGroupsSheet = excelPackage.Workbook.Worksheets.Add(worksheetName);
                ExportUserGroups(userGroupsSheet, excelPackageWithNotes.Workbook.Worksheets[worksheetName]);
                FormatWorksheet(userGroupsSheet);

                //Export fieldgroups
                worksheetName = "Field Groups";
                this.UiHelper.LogInfo(string.Format("Creating {0} sheet...", worksheetName), true);
                ExcelWorksheet fieldGroupsSheet = excelPackage.Workbook.Worksheets.Add(worksheetName);
                ExportFieldGroups(fieldGroupsSheet, excelPackageWithNotes.Workbook.Worksheets[worksheetName]);
                FormatWorksheet(fieldGroupsSheet);

                //Export fields
                worksheetName = "Field Definitions";
                this.UiHelper.LogInfo(string.Format("Creating {0} sheet...", worksheetName), true);
                ExcelWorksheet fieldDefinitionsSheet = excelPackage.Workbook.Worksheets.Add(worksheetName);
                ExportFieldDefinitions(fieldDefinitionsSheet, excelPackageWithNotes.Workbook.Worksheets[worksheetName]);
                FormatWorksheet(fieldDefinitionsSheet);
              
                //Export classifications
                worksheetName = "Classifications";
                this.UiHelper.LogInfo(string.Format("Creating {0} sheet...", worksheetName), true);
                ExcelWorksheet classificationsSheet = excelPackage.Workbook.Worksheets.Add(worksheetName);
                ExportClassifications(classificationsSheet, excelPackageWithNotes.Workbook.Worksheets[worksheetName]);
                FormatWorksheet(classificationsSheet);
                
                //Export security
                this.UiHelper.LogInfo(string.Format("Creating {0} sheet...", worksheetName), true);
                ExcelWorksheet securityPermissionsSheet = excelPackage.Workbook.Worksheets.Add("Access Control List");
                ExportSecurityPermissions(securityPermissionsSheet);
                FormatWorksheet(securityPermissionsSheet, true, 4);

                //Export role permissions
                this.UiHelper.LogInfo(string.Format("Creating {0} sheet...", worksheetName), true);
                ExcelWorksheet rolePermissionsSheet = excelPackage.Workbook.Worksheets.Add("Role Permissions");
                ExportRolePermissions(rolePermissionsSheet);
                FormatWorksheet(rolePermissionsSheet, true, 3);

                //Export Settings
                worksheetName = "Settings";
                this.UiHelper.LogInfo(string.Format("Creating {0} sheet...", worksheetName), true);
                ExcelWorksheet settingsSheet = excelPackage.Workbook.Worksheets.Add(worksheetName);
                ExportSettings(settingsSheet, excelPackageWithNotes.Workbook.Worksheets[worksheetName]);
                FormatWorksheet(settingsSheet);

                //Export Watermarks
                worksheetName = "Watermarks";
                this.UiHelper.LogInfo(string.Format("Creating {0} sheet...", worksheetName), true);
                ExcelWorksheet watermarksSheet = excelPackage.Workbook.Worksheets.Add(worksheetName);
                ExportWatermarks(watermarksSheet, excelPackageWithNotes.Workbook.Worksheets[worksheetName]);
                FormatWorksheet(watermarksSheet);

                //Export Translations
                worksheetName = "Translations";
                this.UiHelper.LogInfo(string.Format("Creating {0} sheet...", worksheetName), true);
                ExcelWorksheet translationsSheet = excelPackage.Workbook.Worksheets.Add(worksheetName);
                ExportTranslations(translationsSheet, excelPackageWithNotes.Workbook.Worksheets[worksheetName]);
                FormatWorksheet(translationsSheet);
                
                //Export Rules
                worksheetName = "Rules";
                this.UiHelper.LogInfo(string.Format("Creating {0} sheet...", worksheetName), true);
                ExcelWorksheet rulesSheet = excelPackage.Workbook.Worksheets.Add(worksheetName);
                ExportRules(rulesSheet, excelPackageWithNotes.Workbook.Worksheets[worksheetName]);
                FormatWorksheet(rulesSheet);
                
                //Export Content types
                worksheetName = "Content types";
                this.UiHelper.LogInfo(string.Format("Creating {0} sheet...", worksheetName), true);
                ExcelWorksheet contentTypesSheet = excelPackage.Workbook.Worksheets.Add(worksheetName);
                ExportContentTypes(contentTypesSheet, excelPackageWithNotes.Workbook.Worksheets[worksheetName]);
                FormatWorksheet(contentTypesSheet);
                
                excelPackage.Save();

                this.UiHelper.LogInfo(string.Format("Done. Total runtime {0}", stopwatch.Elapsed), true);
            }
            catch
            {
                throw;
            }
            finally
            {
                excelPackage.Dispose();
            }
        }

        private void PreloadData()
        {            
            Classifications = LoadAllObjects("{0}/classifications", new Dictionary<string, string>() { { "select-classification", "NamePath" }});
            FieldGroups = LoadAllObjects("{0}/fieldgroups", new Dictionary<string, string>());
            FieldDefinitions = LoadAllObjects("{0}/fielddefinitions", new Dictionary<string, string>());
            UserGroups = LoadAllObjects("{0}/usergroups", new Dictionary<string, string>());
            Watermarks = LoadAllObjects("{0}/watermarks", new Dictionary<string, string>());
            Translations = LoadAllObjects("{0}/translations", new Dictionary<string, string>());
            Rules = LoadAllObjects("{0}/rules", new Dictionary<string, string>() { { "select-Rule", "conditions, actions" } });
            ContentTypes = LoadAllObjects("{0}/contenttypes", new Dictionary<string, string>());
        }

        private void ExportRolePermissions(ExcelWorksheet worksheet)
        {
            //Get all role permissions
            LoadAllRolePermissions();

            int rowIndex = 1;
            int columnIndex = 1;

            //Header row
            worksheet.Cells[rowIndex, columnIndex++].Value = "Functional Permission Name";
            worksheet.Cells[rowIndex, columnIndex++].Value = "Functional Permission Label";

            foreach (Guid userGroupId in UserGroups.Keys)
            {
                worksheet.Cells[rowIndex, columnIndex].Value = UserGroups[userGroupId].name.ToString();
                columnIndex++;
            }
            worksheet.Cells[1, columnIndex].Value = "Notes";
            rowIndex++;

            //First column with permission names
            foreach (string permissionName in RolePermissions.Keys)
            {
                worksheet.Cells[rowIndex, 1].Value = permissionName;
                worksheet.Cells[rowIndex, 2].Value = RolePermissions[permissionName];
                rowIndex++;
            }

            UiHelper.ResetSubProcessProgressBar();
            UiHelper.SetSubProcessProgressBarMaximum(UserGroups.Count);

            foreach (Guid userGroupId in UserGroups.Keys)
            {
                UiHelper.LogInfo(
                    string.Format("Processing functional permissions for user group {0}", UserGroups[userGroupId].name.ToString()),
                    false, true);
                ExportUserGroupRolePermissionPermission(userGroupId, worksheet);
                rowIndex++;
            }
        }

        private void ExportUserGroupRolePermissionPermission(Guid userGroupId, ExcelWorksheet worksheet)
        {
            string url = string.Format("{0}/usergroup/{1}/permissions", AprimoDamUrl, userGroupId);

            dynamic jsonResponse = GetRestResponse(url, new Dictionary<string, string>());

            if ((jsonResponse.items.Count > 0))
            {
                foreach (var permission in jsonResponse.items)
                {
                    int rowIndex = FindRowIndex(worksheet, permission.name.ToString());
                    int columnIndex = FindColumnIndex(worksheet, UserGroups[userGroupId].name.ToString());
                    string permissionValue = permission.value.ToString();
                    if (permissionValue.ToUpperInvariant() != "NONE")
                    {
                        worksheet.Cells[rowIndex, columnIndex].Value = permissionValue;
                    }
                }
            }
        }

        private void LoadAllRolePermissions()
        {
            string url = string.Format("{0}/permissions", AprimoDamUrl);

            do
            {
                dynamic jsonResponse = GetRestResponse(url, new Dictionary<string, string>());
                foreach (dynamic permission in jsonResponse.items)
                {
                    RolePermissions.Add(permission.name.ToString(), permission.labels[0].value.ToString());
                }

                url = (jsonResponse._links.next == null) ? "" : jsonResponse._links.next.href;
            }
            while (url.Length > 0);
        }

        /* DEPRECATED METHOD
        private dynamic GetRestResponseOld(string url)
        {
            
            using (WebClient webClient = new WebClient())
            {
                webClient.Headers.Add("User-Agent", "My Application");
                webClient.Headers.Add("API-VERSION", "1");
                webClient.Headers.Add("Authorization", string.Format("Bearer {0}", Token));
                webClient.Headers.Add("Accept", "application/hal+json");
                webClient.Headers.Add("pageSize", "250");
                webClient.Headers.Add("select-classification", "namepath");
                webClient.Headers.Add("select-rule", "conditions");
                webClient.Headers.Add("select-rule", "actions");

                string response = webClient.DownloadString(url);
                return JsonConvert.DeserializeObject(response);
            }
        }
         */
        private dynamic GetRestResponse(string url, Dictionary<string,string> headers)
        {
           
            var client = new RestClient(url);           
           
            var request = new RestRequest(url, Method.Get);
            var accessToken = accessHelper.GetToken();
            request.AddHeader("Authorization", string.Format("Bearer {0}", accessToken));
            request.AddHeader("Accept", "application/hal+json");
            request.AddHeader("API-VERSION", "1");
            request.AddHeader("pageSize", "500");
            foreach(var header in headers)
            {
                request.AddHeader(header.Key, header.Value);
            }    
                
            RestResponse response = client.Execute(request);
            if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
            {
                accessToken = accessHelper.GetRefreshedToken();
                request.AddOrUpdateParameter("Authorization", string.Format("Bearer " + accessToken));
                response = client.Execute(request);
            }
            if (response.StatusCode.ToString().Equals("OK", StringComparison.OrdinalIgnoreCase))
            {
                return JsonConvert.DeserializeObject(response.Content);
                    
            }
            return null;                 
        }

        private void ExportSecurityPermissions(ExcelWorksheet worksheet)
        {
            int rowIndex = 1;
            int columnIndex = 1;
            UiHelper.ResetSubProcessProgressBar();
            UiHelper.SetSubProcessProgressBarMaximum(Classifications.Count);

            //Header row
            worksheet.Cells[rowIndex, columnIndex++].Value = "Path";
            worksheet.Cells[rowIndex, columnIndex++].Value = "Permission Type";
            worksheet.Cells[rowIndex, columnIndex++].Value = "Break Inheritance";

            foreach (dynamic usergroup in UserGroups.Values)
            {
                worksheet.Cells[1, columnIndex++].Value = usergroup.name.ToString();
            }
            worksheet.Cells[1, columnIndex].Value = "Notes";
            rowIndex++;

            foreach (Guid classificationId in Classifications.Keys)
            {
                string namePath = Classifications[classificationId].namePath.ToString();
                UiHelper.LogInfo(string.Format("Processing security for classification {0}...", namePath), false, true);
                try
                {
                    GetClassificationPermission(worksheet, classificationId, namePath, "ClassificationTreePermissions", ref rowIndex);
                    GetClassificationPermission(worksheet, classificationId, namePath, "RecordPermissions", ref rowIndex);
                    GetClassificationPermission(worksheet, classificationId, namePath, "DownloadPermissions", ref rowIndex);
                }
                catch (Exception)
                {

                }
            }
        }

        public void GetClassificationPermission(ExcelWorksheet worksheet, Guid classificationId, string classificationPath, string permissionType, ref int rowIndex)
        {
            string url = string.Format("{0}/classification/{1}/{2}", AprimoDamUrl, classificationId, permissionType);

            dynamic jsonResponse = GetRestResponse(url, new Dictionary<string, string>());

            if ((jsonResponse.permissions.Count > 0) || (jsonResponse.breakInheritance == true))
            {
                worksheet.Cells[rowIndex, 1].Value = classificationPath;
                worksheet.Cells[rowIndex, 2].Value = permissionType;
                worksheet.Cells[rowIndex, 3].Value = jsonResponse.breakInheritance.ToString();
                foreach (var permission in jsonResponse.permissions)
                {
                    Guid userGroupId = Guid.Parse(permission.userGroupId.ToString());
                    int columnIndex = FindColumnIndex(worksheet, UserGroups[userGroupId].name.ToString());
                    worksheet.Cells[rowIndex, columnIndex].Value = AddSpacesToSentenceCase(permission.accessRight.ToString(), true);
                }
                rowIndex++;
            }
        }

        private int FindColumnIndex(ExcelWorksheet worksheet, string lookupValue, int indexOfRowToSearch = 1)
        {
            try
            {
                for (int i = 1; i <= worksheet.Dimension.Columns; i++)
                {
               
                     if (worksheet.Cells[indexOfRowToSearch, i].Text == lookupValue) return i;
                
                }
            }
            catch (Exception)
            {
                this.UiHelper.LogInfo(string.Format("Warning: couldn't find lookup column value {0}", lookupValue), false, true);
            }

            return 0;
        }

        private int FindRowIndex(ExcelWorksheet worksheet, string lookupValue, int indexOfColumnToSearch = 1)
        {
            try
            {
                for (int i = 1; i <= worksheet.Dimension.Rows; i++)
                {               
                     if (worksheet.Cells[i, indexOfColumnToSearch].Text == lookupValue) return i;
                
                }
            }
            catch (Exception)
            {
                this.UiHelper.LogInfo(string.Format("Warning: couldn't find lookup row value {0}", lookupValue), false, true);
            }

            return 0;
        }

        private void ExportTranslations(ExcelWorksheet worksheet, ExcelWorksheet worksheetWithNotes)
        {
            UiHelper.ResetSubProcessProgressBar();

            worksheet.Cells[1, 1].Value = "ID";
            worksheet.Cells[1, 2].Value = "Studio";
            worksheet.Cells[1, 3].Value = "Module";
            worksheet.Cells[1, 4].Value = "Name";
            worksheet.Cells[1, 5].Value = "Label in English";
            worksheet.Cells[1, 6].Value = "Notes";

            int i = 2;
            UiHelper.SetSubProcessProgressBarMaximum(Translations.Count);

            foreach (dynamic translation in Translations.Values)
            {
                string name = translation.name.ToString();

                UiHelper.LogInfo(string.Format("Processing translation {0}...", name), false, true);

                worksheet.Cells[i, 1].Value = translation.id.ToString();
                worksheet.Cells[i, 2].Value = translation.studio.ToString();
                worksheet.Cells[i, 3].Value = translation.module.ToString();
                worksheet.Cells[i, 4].Value = name;
                worksheet.Cells[i, 5].Value = FindLabelInEnglish(translation.localizedValues);
                worksheet.Cells[i, 6].Value = FindNotesInWorksheet(translation.id.ToString(), worksheetWithNotes);
                i++;
            }

        }

        private void ExportWatermarks(ExcelWorksheet worksheet, ExcelWorksheet worksheetWithNotes)
        {
            UiHelper.ResetSubProcessProgressBar();

            worksheet.Cells[1, 1].Value = "ID";
            worksheet.Cells[1, 2].Value = "Name";
            worksheet.Cells[1, 3].Value = "Notes";

            int i = 2;
            UiHelper.SetSubProcessProgressBarMaximum(Watermarks.Count);
            foreach (dynamic watermark in Watermarks.Values)
            {
                string name = watermark.name.ToString();

                UiHelper.LogInfo(string.Format("Processing watermark {0}...", name), false, true);

                worksheet.Cells[i, 1].Value = watermark.id.ToString();
                worksheet.Cells[i, 2].Value = name;
                worksheet.Cells[i, 3].Value = FindNotesInWorksheet(watermark.id.ToString(), worksheetWithNotes);
                i++;
            }
        }

        private void ExportSettings(ExcelWorksheet worksheet, ExcelWorksheet worksheetWithNotes)
        {
            int i = 1;
            UiHelper.ResetSubProcessProgressBar();
            string url = string.Format("{0}/settingdefinitions", AprimoDamUrl);

            worksheet.Cells[i, 1].Value = "ID";
            worksheet.Cells[i, 2].Value = "Name";
            worksheet.Cells[i, 3].Value = "Label";
            worksheet.Cells[i, 4].Value = "Value";
            worksheet.Cells[i, 5].Value = "Notes";
            i++;

            do
            {
                dynamic jsonResponse = GetRestResponse(url, new Dictionary<string, string>());

                if (i == 2) UiHelper.SetSubProcessProgressBarMaximum(int.Parse(jsonResponse.totalCount.ToString()));

                foreach (dynamic settingDefinition in jsonResponse.items)
                {
                    string name = settingDefinition.name.ToString();

                    UiHelper.LogInfo(string.Format("Processing setting {0}...", name), false, true);

                    //GetSetting is not supported for role-settings or settings with a UserGroupSettingMode set to Manual.
                    if ((settingDefinition.dataType.ToString().ToUpperInvariant() != "ROLE") &&
                        (settingDefinition.userGroupSettingMode.ToString().ToUpperInvariant() != "MANUAL"))

                    {
                        string defaultValue = settingDefinition.defaultValue.ToString();
                        dynamic setting = GetRestResponse(string.Format("{0}/setting/{1}", AprimoDamUrl, name), new Dictionary<string, string>());
                        string settingValue = setting.value.ToString();

                        if (settingValue != defaultValue)
                        {
                            worksheet.Cells[i, 1].Value = settingDefinition.id.ToString();
                            worksheet.Cells[i, 2].Value = name;
                            worksheet.Cells[i, 3].Value = FindLabelInEnglish(settingDefinition.labels);
                            worksheet.Cells[i, 4].Value = settingValue;
                            worksheet.Cells[i, 5].Value = FindNotesInWorksheet(name.ToString(), worksheetWithNotes);
                            i++;
                        }
                    }
                }

                url = (jsonResponse._links.next == null) ? "" : jsonResponse._links.next.href;
            }
            while (url.Length > 0);
        }

        private void ExportRules(ExcelWorksheet worksheet, ExcelWorksheet worksheetWithNotes)
        {

            UiHelper.ResetSubProcessProgressBar();

            worksheet.Cells[1, 1].Value = "ID";
            worksheet.Cells[1, 2].Value = "Name";
            worksheet.Cells[1, 3].Value = "Target";
            worksheet.Cells[1, 4].Value = "Trigger";
            worksheet.Cells[1, 5].Value = "Enabled";
            worksheet.Cells[1, 6].Value = "Conditions";
            worksheet.Cells[1, 7].Value = "Actions";
            worksheet.Cells[1, 9].Value = "Notes";
            worksheet.Cells[1, 8].Value = "Enabled on drafts";

            int i = 2;
            UiHelper.SetSubProcessProgressBarMaximum(Rules.Count);
            foreach (dynamic rule in Rules.Values)
            {
                
                    string name = rule.name.ToString();
               
                    UiHelper.LogInfo(string.Format("Processing rule {0}...", name), false, true);
                try
                {
                    worksheet.Cells[i, 1].Value = rule.id.ToString();
                    worksheet.Cells[i, 2].Value = name;
                    worksheet.Cells[i, 3].Value = rule.target.ToString();
                    worksheet.Cells[i, 4].Value = AddSpacesToSentenceCase(rule.trigger.ToString(), true);
                    worksheet.Cells[i, 5].Value = rule.enabled.ToString();
                    worksheet.Cells[i, 6].Value = GetRuleConditionsText(rule._embedded.conditions.items);
                    worksheet.Cells[i, 7].Value = GetRuleActionsText(rule._embedded.actions.items);
                    worksheet.Cells[i, 9].Value = FindNotesInWorksheet(rule.id.ToString(), worksheetWithNotes);
                    worksheet.Cells[i, 8].Value = rule.includeDraftRecords.ToString();
                } catch (System.Exception ex) { UiHelper.LogInfo(string.Format("Error happened while processing rule {0}, error message: {1}", name, ex.Message), false, true); } 
                i++;
            }
        }

        private object GetRuleActionsText(dynamic actions)
        {
            List<string> actionTexts = new List<string>();

            foreach (dynamic action in actions)
            {
                Guid id;
                string gettingType;
                string label;
                switch (action.actionType.ToString().ToUpper())
                {
                    case "REFRESHFILES":
                        actionTexts.Add("recreate the preview(s) of the record");
                        break;
                    case "REFERENCE":
                        actionTexts.Add(string.Format("execute the following reference:\n{0}", action.reference.ToString()));
                        break;
                    case "APPLYWATERMARKONMASTERFILE":

                        if (action.watermarkType.ToString().ToUpperInvariant() == "NONE")
                        {
                            actionTexts.Add("Remove watermark on the master file of the record");
                        }
                        else
                        {
                            if (action.watermarkType.ToString().ToUpperInvariant() == "USESETTING")
                            {
                                actionTexts.Add("apply the watermark specified in the user's .watermarkName-setting on the master file of the record");
                            }
                            else
                            {
                                id = Guid.Parse(action.watermarkId.ToString());
                                label = (Watermarks.ContainsKey(id)) ? Watermarks[id].name.ToString() : id.ToString();
                                actionTexts.Add(string.Format("apply '{0}' watermark on the master file of the record", label));
                            }
                        }
                        break;
                    case "CLASSIFYRECORD":
                        gettingType = action.gettingType.ToString();
                        if (gettingType.ToUpperInvariant() == "SPECIFIED")
                        {
                            id = Guid.Parse(action.classificationId.ToString());
                            label = (Classifications.ContainsKey(id)) ? Classifications[id].namePath.ToString() : id.ToString();
                            actionTexts.Add(string.Format("classify record in '{0}'", label));
                        }
                        if (gettingType.ToUpperInvariant() == "CALCULATEDBYREFERENCE")
                        {
                            actionTexts.Add(string.Format("classify record in classification with {0} found by resolving reference {1}",
                                action.identifierType.ToString().ToLowerInvariant(),
                                action.reference.ToString()));
                        }
                        break;
                    case "SCHEDULERESAVEOFRECORD":
                        id = Guid.Parse(action.fieldDefinitionId.ToString());
                        label = (FieldDefinitions.ContainsKey(id)) ? FieldDefinitions[id].name.ToString() : id.ToString();
                        actionTexts.Add(string.Format("schedule the record to be resaved on the date specified in {0}", label));
                        break;
                    case "UNCLASSIFYRECORD":
                        string result = "";
                        gettingType = action.gettingType.ToString();
                        if (gettingType.ToUpperInvariant() == "SPECIFIED")
                        {
                            result = "unlink record from classification(s) ";
                            foreach (dynamic classificationId in action.classificationIds)
                            {
                                id = Guid.Parse(classificationId.ToString());
                                label = (Classifications.ContainsKey(id)) ? Classifications[id].namePath.ToString() : id.ToString();
                                result += string.Format("'{0}' ", label);
                            }
                        }
                        if (gettingType.ToUpperInvariant() == "CALCULATEDBYREFERENCE")
                        {
                            result = string.Format("unlink record from classification with {0} found by resolving reference {1}",
                                action.identifierType.ToString().ToLowerInvariant(),
                                action.reference.ToString());
                        }
                        if (action.unlinkTarget.ToString().ToUpperInvariant() == "CLASSIFICATIONSDESCENDANTS")
                        {
                            result += " and all of its descendants";
                        }
                        actionTexts.Add(result);
                        break;
                    case "SETFIELDVALUE":
                        id = Guid.Parse(action.fieldDefinitionId.ToString());
                        label = (FieldDefinitions.ContainsKey(id)) ? FieldDefinitions[id].name.ToString() : id.ToString();
                        actionTexts.Add(string.Format("set value of {0} to {1}", label, action.reference.ToString()));
                        break;
                    case "SENDEMAIL":
                        actionTexts.Add(string.Format("send email using the following reference:\n{0}", action.reference.ToString()));
                        break;
                    case "CREATEPRESETCROPS":
                        actionTexts.Add("create preset crops for the record");
                        break;
                    case "APRIMOAI":
                        actionTexts.Add(string.Format("extract {0} from the file using Aprimo AI", action.options.ToString()));
                        break;
                    case "CREATEREVIEWFILE":
                        actionTexts.Add("create the review file for the record");
                        break;
                    case "CREATERENDITIONS":
                        actionTexts.Add(string.Format("update the record with renditions for preset(s) {0}", action.renditionPresets.ToString()));
                        break;
                    case "CHANGECONTENTTYPE":
                        actionTexts.Add(string.Format("change the content type to {0}", action.ContentType.ToString()));
                        break;
                    case "CHANGERECORDSTATUS":
                        actionTexts.Add(string.Format("change the record status to {0}", action.status.ToString()));
                        break;
                    case "CREATEPUBLICLINKS":
                        actionTexts.Add(string.Format("create public links"));
                        break;
                    case "DELETEPUBLICLINKS":
                        actionTexts.Add(string.Format("delete public links"));
                        break;
                    default:
                        actionTexts.Add(string.Format("{0} (unknown action type - add type to GetRuleActionsText-method)", action.actionType.ToString()));
                        break;
                }
            }

            return string.Join(" AND ", actionTexts.ToArray());
        }

        private string GetRuleConditionsText(dynamic conditions)
        {
            List<string> conditionTexts = new List<string>();

            foreach (dynamic condition in conditions)
            {
                Guid id;
                bool directLinkOnly;
                string directly;
                string label;
                switch (condition.conditionType.ToString().ToUpper())
                {
                    case "HASFIELDVALUECHANGED":
                        id = Guid.Parse(condition.fieldDefinitionId.ToString());
                        label = (FieldDefinitions.ContainsKey(id)) ? FieldDefinitions[id].name.ToString() : id.ToString();
                        conditionTexts.Add(string.Format("{0} field has changed", label));
                        break;
                    case "CLASSIFICATIONLINKED":
                        id = Guid.Parse(condition.classificationId.ToString());
                        label = (Classifications.ContainsKey(id)) ? Classifications[id].namePath.ToString() : id.ToString();
                        directLinkOnly = bool.Parse(condition.directLinkOnly.ToString());
                        directly = (directLinkOnly) ? "directly " : "";
                        conditionTexts.Add(string.Format("the record was {0}linked to classification '{1}'", directly, label));
                        break;
                    case "CLASSIFICATIONUNLINKED":
                        id = Guid.Parse(condition.classificationId.ToString());
                        label = (Classifications.ContainsKey(id)) ? Classifications[id].namePath.ToString() : id.ToString();
                        directLinkOnly = bool.Parse(condition.directLinkOnly.ToString());
                        directly = (directLinkOnly) ? "directly " : "";
                        conditionTexts.Add(string.Format("the record was {0}unlinked from classification '{1}'", directly, label));
                        break;
                    case "CLASSIFIEDIN":
                        id = Guid.Parse(condition.classificationId.ToString());
                        label = (Classifications.ContainsKey(id)) ? Classifications[id].namePath.ToString() : id.ToString();
                        directLinkOnly = bool.Parse(condition.directLinkOnly.ToString());
                        directly = (directLinkOnly) ? "directly " : "";
                        conditionTexts.Add(string.Format("the record is {0}classified in classification '{1}'", directly, label));
                        break;
                    case "CURRENTLYLOGGEDONUSER":
                        id = Guid.Parse(condition.userId.ToString());
                        conditionTexts.Add(string.Format("the user triggering the rule is user with id {0}", id));
                        break;
                    case "FILEADDED":
                        conditionTexts.Add("a object was changed");
                        break;
                    case "MOVIEADDEDWITHOUTMOVIEPREVIEW":
                        conditionTexts.Add("a movie was added without preview");
                        break;
                    case "OBJECTCHANGED":
                        conditionTexts.Add("the object was changed");
                        break;
                    case "OBJECTCREATEDORCHANGED":
                        conditionTexts.Add("the object was created or changed");
                        break;
                    case "OBJECTCREATED":
                        conditionTexts.Add("the object was created");
                        break;
                    case "OBJECTDELETED":
                        conditionTexts.Add("the object was deleted");
                        break;
                    case "REFERENCE":
                        conditionTexts.Add(string.Format("the following reference returned true: {0}", condition.reference.ToString()));
                        break;
                    case "COMPAREFIELDVALUE":
                        conditionTexts.Add(string.Format("the following expression is true: {0}", condition.expression.ToString()));
                        break;
                    case "CONTENTTYPEIS":
                        conditionTexts.Add(string.Format("the content type is {0}", condition.contentType.ToString()));
                        break;
                    case "CONTENTTYPESETTO":
                        conditionTexts.Add(string.Format("the content type has just been set to {0}", condition.contentType.ToString()));
                        break;
                    case "CONTENTTYPECHANGED":
                        conditionTexts.Add(string.Format("the content type has changed"));
                        break;
                    case "RECORDSTATUSIS":
                        conditionTexts.Add(string.Format("the record status is {0}", condition.status.ToString()));
                        break;
                    case "RECORDSTATUSSETTO":
                        conditionTexts.Add(string.Format("the record status has just been set to {0}", condition.status.ToString()));
                        break;
                    case "RECORDSTATUSCHANGED":
                        conditionTexts.Add(string.Format("the record status has changed"));
                        break;
                    case "MASTERPREVIEWEXISTS":
                        conditionTexts.Add("the record has a master preview");
                        break;
                    case "MASTERPREVIEWCHANGED":
                        conditionTexts.Add("the record has a new master preview");
                        break;
                    default:
                        conditionTexts.Add(string.Format("{0} (unknown condition type - add type to GetRuleConditionsText-method)", condition.conditionType.ToString()));
                        break;
                }
            }

            return string.Format("if {0}", string.Join(" AND ", conditionTexts.ToArray()));
        }

        private void ExportContentTypes(ExcelWorksheet worksheet, ExcelWorksheet worksheetWithNotes)
        {

            UiHelper.ResetSubProcessProgressBar();

            worksheet.Cells[1, 1].Value = "ID";
            worksheet.Cells[1, 2].Value = "Name";
            worksheet.Cells[1, 3].Value = "Purpose";
            worksheet.Cells[1, 4].Value = "Parent";
            worksheet.Cells[1, 5].Value = "Fields";
            worksheet.Cells[1, 6].Value = "File extensions";
            worksheet.Cells[1, 7].Value = "Title config";
            worksheet.Cells[1, 8].Value = "Title field (not)";
            worksheet.Cells[1, 9].Value = "Inheritance";
            worksheet.Cells[1, 10].Value = "Inheritance link field";
            worksheet.Cells[1, 11].Value = "Inheritable fields";
            worksheet.Cells[1, 12].Value = "Notes";

            int i = 2;
            UiHelper.SetSubProcessProgressBarMaximum(ContentTypes.Count);
            foreach (dynamic contentType in ContentTypes.Values)
            {
                string name = contentType.name.ToString();

                UiHelper.LogInfo(string.Format("Processing content type {0}...", name), false, true);

                worksheet.Cells[i, 1].Value = contentType.id.ToString();
                worksheet.Cells[i, 2].Value = name;
                worksheet.Cells[i, 3].Value = contentType.purpose.ToString();
                worksheet.Cells[i, 4].Value = contentType.parentId.ToString();
                worksheet.Cells[i, 5].Value = string.Join(", ", ConvertRegisteredFieldIdsToNames(contentType.registeredFields));
                worksheet.Cells[i, 6].Value = string.Join(", ", JsonArrayToString(contentType.defaultFileExtensions));
                worksheet.Cells[i, 7].Value = contentType.titleConfiguration.ToString();
                worksheet.Cells[i, 9].Value = contentType.inheritanceConfiguration.ToString();
                worksheet.Cells[i, 10].Value = contentType.inheritanceFieldId.ToString();
                worksheet.Cells[i, 11].Value = string.Join(", ", ConvertRegisteredFieldIdsToNames(contentType.inheritableFields));
                worksheet.Cells[i, 12].Value = FindNotesInWorksheet(contentType.id.ToString(), worksheetWithNotes);
                i++;
            }
        }

        private void ExportUserGroups(ExcelWorksheet worksheet, ExcelWorksheet worksheetWithNotes)
        {
            UiHelper.ResetSubProcessProgressBar();

            worksheet.Cells[1, 1].Value = "ID";
            worksheet.Cells[1, 2].Value = "Name";
            worksheet.Cells[1, 3].Value = "Notes";

            int i = 2;
            UiHelper.SetSubProcessProgressBarMaximum(UserGroups.Count);
            foreach (dynamic userGroup in UserGroups.Values)
            {
                string name = userGroup.name.ToString();

                UiHelper.LogInfo(string.Format("Processing user group {0}...", name), false, true);

                worksheet.Cells[i, 1].Value = userGroup.id.ToString();
                worksheet.Cells[i, 2].Value = name;
                worksheet.Cells[i, 3].Value = FindNotesInWorksheet(userGroup.id.ToString(), worksheetWithNotes);
                i++;
            }
        }

        private string FindNotesInWorksheet(string lookup, ExcelWorksheet worksheet, int lookupColumnIndex = 1)
        {
            if (worksheet != null)
            {
                int notesColumnIndex = 0;

                for (int j = 1; j <= worksheet.Dimension.Columns; j++)
                {
                    if (worksheet.Cells[1, j].Text.ToUpperInvariant() == "NOTES")
                    {
                        notesColumnIndex = j;
                        break;
                    }
                }

                if (notesColumnIndex > 0)
                {
                    for (int i = 1; i <= worksheet.Dimension.Rows; i++)
                    {
                        if (worksheet.Cells[i, lookupColumnIndex].Text == lookup)
                        {
                            return worksheet.Cells[i, notesColumnIndex].Text;
                        }
                    }
                }
            }
            return "";
        }

        private void ExportClassifications(ExcelWorksheet worksheet, ExcelWorksheet worksheetWithNotes)
        {
            worksheet.Cells[1, 1].Value = "ID";
            worksheet.Cells[1, 2].Value = "Name";
            worksheet.Cells[1, 3].Value = "Label";
            worksheet.Cells[1, 4].Value = "Identifier";
            worksheet.Cells[1, 5].Value = "NamePath";
            worksheet.Cells[1, 6].Value = "Registered Field Groups";
            worksheet.Cells[1, 7].Value = "Registered Fields";
            worksheet.Cells[1, 8].Value = "Notes";

            int i = 2;
            UiHelper.SetSubProcessProgressBarMaximum(Classifications.Count);
            foreach (dynamic classification in Classifications.Values)
            {
                string namePath = classification.namePath.ToString();

                UiHelper.LogInfo(string.Format("Processing classification {0}...", namePath), false, true);

                worksheet.Cells[i, 1].Value = classification.id.ToString();
                worksheet.Cells[i, 2].Value = classification.name.ToString();
                worksheet.Cells[i, 3].Value = FindLabelInEnglish(classification.labels);
                worksheet.Cells[i, 4].Value = classification.identifier.ToString();
                worksheet.Cells[i, 5].Value = namePath;
                worksheet.Cells[i, 6].Value = string.Join(", ", ConvertRegisteredFieldGroupIdsToNames(classification.registeredFieldGroups));
                worksheet.Cells[i, 7].Value = string.Join(", ", ConvertRegisteredFieldIdsToNames(classification.registeredFields));
                try
                {
                    worksheet.Cells[i, 8].Value = FindNotesInWorksheet(classification.id.ToString(), worksheetWithNotes);
                }
                catch (Exception)
                {
                }
                i++;
            }
        }

        private Dictionary<Guid, dynamic> LoadAllObjects(string url, Dictionary<string, string> headers)
        {
            Dictionary<Guid, dynamic> result = new Dictionary<Guid, dynamic>();
            url = string.Format(url, AprimoDamUrl);

            do
            {
                dynamic jsonResponse = GetRestResponse(url, headers);

                foreach (dynamic item in jsonResponse.items)
                {
                    result.Add(Guid.Parse(item.id.ToString()), item);
                }

                url = (jsonResponse._links.next == null) ? "" : jsonResponse._links.next.href;
            }
            while (url.Length > 0);

            return result;
        }

        private string[] ConvertRegisteredFieldGroupIdsToNames(dynamic fieldGroups)
        {
            List<string> result = new List<string>();

            foreach (dynamic item in fieldGroups)
            {
                Guid id = Guid.Parse(item.fieldGroupId.ToString());
                result.Add(FieldGroups[id].name.ToString());
            }

            return result.ToArray();
        }

        private string[] ConvertRegisteredFieldIdsToNames(dynamic fields)
        {
            List<string> result = new List<string>();

            foreach (dynamic item in fields)
            {
                Guid id = Guid.Parse(item.fieldId.ToString());
                result.Add(FieldDefinitions[id].name.ToString());
            }

            return result.ToArray();
        }


        private object FindLabelInEnglish(dynamic labels)
        {
            foreach (dynamic item in labels)
            {
                Guid languageId = Guid.Parse(item.languageId.ToString());
                if (languageId == EnglishLanguageId) return item.value.ToString();
            }

            return "";
        }

        private void ExportFieldGroups(ExcelWorksheet worksheet, ExcelWorksheet worksheetWithNotes)
        {
            UiHelper.ResetSubProcessProgressBar();

            worksheet.Cells[1, 1].Value = "ID";
            worksheet.Cells[1, 2].Value = "Name";
            worksheet.Cells[1, 3].Value = "Notes";

            int i = 2;
            UiHelper.SetSubProcessProgressBarMaximum(FieldGroups.Count);
            foreach (dynamic fieldGroup in FieldGroups.Values)
            {
                string name = fieldGroup.name.ToString();

                UiHelper.LogInfo(string.Format("Processing field group {0}...", name), false, true);

                worksheet.Cells[i, 1].Value = fieldGroup.id.ToString();
                worksheet.Cells[i, 2].Value = name;
                worksheet.Cells[i, 3].Value = FindNotesInWorksheet(fieldGroup.id.ToString(), worksheetWithNotes);
                i++;

            }
        }

        private void ExportFieldDefinitions(ExcelWorksheet worksheet, ExcelWorksheet worksheetWithNotes)
        {
            UiHelper.ResetSubProcessProgressBar();

            worksheet.Cells[1, 1].Value = "ID";
            worksheet.Cells[1, 2].Value = "Name";
            worksheet.Cells[1, 3].Value = "Label";
            worksheet.Cells[1, 4].Value = "Data Type";
            worksheet.Cells[1, 5].Value = "Scope";
            worksheet.Cells[1, 6].Value = "Required";
            worksheet.Cells[1, 7].Value = "Searchable";
            worksheet.Cells[1, 8].Value = "Read only";
            worksheet.Cells[1, 9].Value = "Default Value";
            worksheet.Cells[1, 10].Value = "Default Value Triggers";
            worksheet.Cells[1, 11].Value = "Validation";
            worksheet.Cells[1, 12].Value = "Validation message";
            worksheet.Cells[1, 13].Value = "Field Groups";
            worksheet.Cells[1, 14].Value = "Sort index";
            worksheet.Cells[1, 15].Value = "Help text";
            worksheet.Cells[1, 16].Value = "Additional Info";
            worksheet.Cells[1, 17].Value = "Notes";


            int i = 2;
            UiHelper.SetSubProcessProgressBarMaximum(FieldDefinitions.Count);
            foreach (dynamic fieldDefinition in FieldDefinitions.Values)
            {
                string name = fieldDefinition.name.ToString();

                UiHelper.LogInfo(string.Format("Processing field definition {0}...", name), false, true);

                worksheet.Cells[i, 1].Value = fieldDefinition.id.ToString();
                worksheet.Cells[i, 2].Value = name;
                worksheet.Cells[i, 3].Value = fieldDefinition.label.ToString();
                worksheet.Cells[i, 4].Value = AddSpacesToSentenceCase(fieldDefinition.dataType.ToString(), true);
                worksheet.Cells[i, 5].Value = AddSpacesToSentenceCase(fieldDefinition.scope.ToString(), true);
                worksheet.Cells[i, 6].Value = fieldDefinition.isRequired.ToString();
                worksheet.Cells[i, 7].Value = fieldDefinition.indexed.ToString();
                worksheet.Cells[i, 8].Value = fieldDefinition.isReadOnly.ToString();
                worksheet.Cells[i, 9].Value = fieldDefinition.defaultValue.ToString();
                worksheet.Cells[i, 10].Value = JsonArrayToString(fieldDefinition.resetToDefaultTriggers);
                worksheet.Cells[i, 11].Value = fieldDefinition.validation.ToString();
                worksheet.Cells[i, 12].Value = fieldDefinition.validationErrorMessage.ToString();
                worksheet.Cells[i, 13].Value = string.Join(", ", ConvertFieldGroupIdsToNames(fieldDefinition.memberships));
                worksheet.Cells[i, 14].Value = fieldDefinition.sortIndex.ToString();
                worksheet.Cells[i, 15].Value = fieldDefinition.helpText.ToString();
                worksheet.Cells[i, 16].Value = GetAdditionalInfoForFieldDefinition(fieldDefinition, worksheet.Workbook, worksheetWithNotes);
                worksheet.Cells[i, 17].Value = FindNotesInWorksheet(fieldDefinition.id.ToString(), worksheetWithNotes);

                i++;
            }
        }

        private string GetAdditionalInfoForFieldDefinition(dynamic fieldDefinition, ExcelWorkbook workbook, ExcelWorksheet worksheetWithNotes)
        {
            try
            {
                switch (fieldDefinition.dataType.ToString().ToUpper())
            {
                case "OPTIONLIST":
                    string fieldName = fieldDefinition.name.ToString();
                    AddOptionsToWorksheet(fieldName, workbook, fieldDefinition.items, worksheetWithNotes);
                    return string.Format("See 'Option List Items'-tab for list of available options and filter on 'Field Name' = {0}", fieldName);
                case "CLASSIFICATIONLIST":
                    Guid rootId = Guid.Parse(fieldDefinition.rootId.ToString());
                    string label = (rootId == Guid.Empty) ? "Top Level" : Classifications[rootId].namePath.ToString();
                    string filter = fieldDefinition.filter.ToString();
                    string linkToSelected = fieldDefinition.linkRecordToSelectedClassifications.ToString();
                    string multiselect = fieldDefinition.acceptMultipleOptions.ToString();
                    return string.Format("Uses '{0}' as root for showing available options, with filter '{1}'. Link records to selected classifications: '{2}', multi-select: '{3}'", label, filter, linkToSelected, multiselect);
                default:
                    break;
            }
            }
            catch (Exception ex) { }
            return "";
        }

        private void AddOptionsToWorksheet(string fieldName, ExcelWorkbook workbook, dynamic options, ExcelWorksheet worksheetWithNotes)
        {
            int i;
            string tabName = "Option List Items";
            //Create work sheet if it does not exist yet
            ExcelWorksheet worksheet = workbook.Worksheets[tabName];
            if (worksheet == null)
            {
                worksheet = workbook.Worksheets.Add(tabName);
                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "Field Name";
                worksheet.Cells[1, 3].Value = "Option Name";
                worksheet.Cells[1, 4].Value = "Option Label";
                worksheet.Cells[1, 5].Value = "Notes";

                i = 2;
            }
            else
            {
                i = worksheet.Dimension.Rows + 1;
            }

            foreach (var option in options)
            {
                worksheet.Cells[i, 1].Value = option.id.ToString();
                worksheet.Cells[i, 2].Value = fieldName;
                worksheet.Cells[i, 3].Value = option.name.ToString();
                worksheet.Cells[i, 4].Value = option.label.ToString();
                if ((worksheetWithNotes != null) &&
                    (worksheetWithNotes.Workbook != null) &&
                    (worksheetWithNotes.Workbook.Worksheets[tabName] != null))
                {
                    worksheet.Cells[i, 4].Value = FindNotesInWorksheet(option.id.ToString(), worksheetWithNotes.Workbook.Worksheets[tabName]);
                }
                i++;
            }

            FormatWorksheet(worksheet);
        }

        private string JsonArrayToString(dynamic array)
        {
            List<string> result = new List<string>();

            foreach (dynamic item in array)
            {
                result.Add(item.ToString());
            }

            return string.Join(", ", result.ToArray());
        }

        private string[] ConvertFieldGroupIdsToNames(dynamic groupIds)
        {
            List<string> result = new List<string>();

            foreach (dynamic groupId in groupIds)
            {
                Guid id = Guid.Parse(groupId.ToString());
                result.Add(FieldGroups[id].name.ToString());
            }

            return result.ToArray();
        }

        private string[] ConvertFieldIdsToNames(dynamic fieldIds)
        {
            List<string> result = new List<string>();

            foreach (dynamic fieldId in fieldIds)
            {
                Guid id = Guid.Parse(fieldId.ToString());
                result.Add(FieldDefinitions[id].name.ToString());
            }

            return result.ToArray();
        }

        string AddSpacesToSentenceCase(string text, bool preserveAcronyms)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]))
                    if ((text[i - 1] != ' ' && !char.IsUpper(text[i - 1])) ||
                        (preserveAcronyms && char.IsUpper(text[i - 1]) &&
                         i < text.Length - 1 && !char.IsUpper(text[i + 1])))
                        newText.Append(' ');
                newText.Append(text[i]);
            }
            return newText.ToString();
        }

        private void FormatWorksheet(ExcelWorksheet worksheet, bool deleteEmptyColumns = false, int rotateHeaderColumnFromIndex = 0)
        {
            //Autofit column width
            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

            //Set header row in bold, apply background color, apply vertical text orientation
            ExcelRange headerCells = worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column];
            ExcelFill headerFill = headerCells.Style.Fill;
            headerFill.PatternType = ExcelFillStyle.Solid;
            headerFill.BackgroundColor.SetColor(Color.Gray);
            headerCells.Style.Font.Bold = true;
            if (rotateHeaderColumnFromIndex > 0)
            {
                worksheet.Cells[1, rotateHeaderColumnFromIndex, 1, worksheet.Dimension.End.Column].Style.TextRotation = 90;
            }

            if (deleteEmptyColumns)
            {
                //if a column is completely blank (except for the headerrow): delete it
                for (int j = worksheet.Dimension.End.Column; j >= 1; j--)
                {
                    bool columnIsBlank = true;
                    for (int i = 2; i < worksheet.Dimension.End.Row; i++)
                    {
                        if (worksheet.Cells[i, j].Text.Length > 0)
                        {
                            columnIsBlank = false;
                            break;
                        }
                    }

                    //Never delete the 'Notes'-column
                    if ((columnIsBlank) && (worksheet.Cells[1, j].Text.ToUpperInvariant() != "NOTES"))
                    {
                        worksheet.DeleteColumn(j);
                    }
                }
            }

            //Wrap text
            for (int j = worksheet.Dimension.End.Column; j >= 1; j--)
            {
                worksheet.Column(j).Style.WrapText = true;
            }

            //Enable filter for header row
            worksheet.Cells[worksheet.Dimension.Address].AutoFilter = true;


            //for (int i = 1; i < worksheet.Dimension.Columns; i++)
            //{
            //    worksheet.Column(i).BestFit = true;
            //    worksheet.Column(i).AutoFit();
            //}

        }

        private void Logon()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                     | SecurityProtocolType.Tls11
                                     | SecurityProtocolType.Tls12;

            string basicToken = Convert.ToBase64String(
            Encoding.UTF8.GetBytes(string.Format("{0}:{1}",
            UserName, UserToken)));

            using (WebClient webClient = new WebClient())
            {
                webClient.Headers.Add("client-id", ClientId);
                webClient.Headers.Add("Authorization", string.Format("Basic {0}", basicToken));

                string response = Encoding.ASCII.GetString(webClient.UploadData(AprimoMoUrl, new byte[] { }));
                dynamic jsonResponse = JsonConvert.DeserializeObject(response);
                Token = jsonResponse.accessToken;
            }

        }
    }
}