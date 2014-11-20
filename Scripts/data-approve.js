var app = angular.module('cbsApp', ['ngGrid']);
app.controller('DataApproveCtrl', function ($scope, $http) {

    $scope.CBS_AttendancesData = {};
    $scope.CBS_AwardsData = {};
    $scope.CBS_BonusesData = {};
    $scope.CBS_CustomerFeedbackScoreData = {};
    $scope.CBS_EmployeeBillingUtilizationData = {};

    //$scope.CBS_EmployeesData = {};
    $scope.CBS_EngagementData = {};
    $scope.CBS_FuelAllowancesData = {};
    $scope.CBS_IncrementsData = {};
    $scope.CBS_MentorBuddyData = {};

    $scope.CBS_PromotionsData = {};
    $scope.CBS_PublicAppearencesData = {};
    //$scope.CBS_ReportFormatData = {};
    $scope.CBS_TechnologyExposureData = {};
    $scope.CBS_TrainingsData = {};

    $scope.CBS_TravelsData = {};
    $scope.CBS_UniversitySessionsData = {};
    $scope.CBS_ValueInnovationsData = {};
    $scope.CBS_SalaryInformationData = {};
    $scope.CBS_AdditionalAccomplishmentsData = {};
    $scope.CBS_BenefitsData = {};

    //Get the Json data from GetInitialData() where all the unapproved data . You get the data as a list from "data" 
    $http.get('/Admin/DataApprove/GetInitialData/').
          success(function (data, status, headers, config) {
              // this callback will be called asynchronously
              // when the response is available
              $scope.CBS_AttendancesData = data.cbs_AttendancesList;
              $scope.CBS_AwardsData = data.cbs_AwardsList;
              $scope.CBS_BonusesData = data.cbs_BonusesList;
              $scope.CBS_CustomerFeedbackScoreData = data.cbs_CustomerFeedbackScoreList;
              $scope.CBS_EmployeeBillingUtilizationData = data.cbs_EmployeeBillingUtilizationList;

              //$scope.CBS_EmployeesData = data.cbs_employees;
              $scope.CBS_EngagementData = data.cbs_EngagementList;
              $scope.CBS_FuelAllowancesData = data.cbs_FuelAllowancesList;
              $scope.CBS_IncrementsData = data.cbs_IncrementsList;
              $scope.CBS_MentorBuddyData = data.cbs_MentorBuddyList;

              $scope.CBS_PromotionsData = data.cbs_PromotionsList;
              $scope.CBS_PublicAppearencesData = data.cbs_PublicAppearencesList;
              //$scope.CBS_ReportFormatData = data.cbs_ReportFormatList;
              $scope.CBS_TechnologyExposureData = data.cbs_TechnologyExposureList;
              $scope.CBS_TrainingsData = data.cbs_TrainingsList;

              $scope.CBS_TravelsData = data.cbs_TravelsList;
              $scope.CBS_UniversitySessionsData = data.cbs_UniversitySessionsList;
              $scope.CBS_ValueInnovationsData = data.cbs_ValueInnovationsList;
              $scope.CBS_SalaryInformationData = data.CBS_SalaryInformationList;
              $scope.CBS_AdditionalAccomplishmentsData = data.CBS_AdditionalAccomplishmentsList;
              $scope.CBS_BenefitsData = data.CBS_BenefitsList;
          }).
          error(function (data, status, headers, config) {
              // called asynchronously if an error occurs
              // or server returns response with an error status.
          });

    //The data got from GetInitialData will be sorted out and displayed in the Grid 
    $scope.CBS_AttendancesGridOptions = {
        data: 'CBS_AttendancesData',
        selectedItems: [],
        multiSelect: true,
        columnDefs: [
            { field: 'EmpID', displayName: 'Employee ID' },
            { field: 'Employee_Name', displayName: 'Employee Name' },
            { field: 'Date', displayName: 'Date' },
            { field: 'Average_InTime', displayName: 'Average InTime' },
            { field: 'Average_OutTime', displayName: 'Average OutTime' },
            { field: 'Weekends_Worked', displayName: 'Weekends Worked' },
            { field: 'Medical_Leaves_Taken', displayName: 'Medical Leaves Taken' },
            { field: 'Casual_Leaves_Taken', displayName: 'Casual Leaves Taken' },
            { field: 'Annual_Leaves_Taken', displayName: 'Annual Leaves Taken' },
            { field: 'Lieu_Leaves_Taken', displayName: 'Lieu Leaves Taken' },
            { field: 'Number_of_Days_Reported_to_Work', displayName: 'Number of Days Reported to Work' }
        ]

    };
    $scope.CBS_AwardsGridOptions = {
        data: 'CBS_AwardsData',
        selectedItems: [],
        multiSelect: true,
        columnDefs: [
            { field: 'EmpID', displayName: 'Employee ID' },
            { field: 'Employee_Name', displayName: 'Employee Name' },
            { field: 'Award_Date', displayName: 'Award Date' },
            { field: 'Award', displayName: 'Award' }
        ]

    };
    $scope.CBS_BonusesGridOptions = {
        data: 'CBS_BonusesData',
        selectedItems: [],
        multiSelect: true,
        columnDefs: [
            { field: 'EmpID', displayName: 'Employee ID' },
            { field: 'Employee_Name', displayName: 'Employee Name' },
            { field: 'Date', displayName: 'Date' },
            { field: 'Bonus_Type', displayName: 'Bonus Type' },
            { field: 'Bonus_Amount', displayName: 'Bonus Amount' }
        ]

    };
    $scope.CBS_CustomerFeedbackScoreGridOptions = {
        data: 'CBS_CustomerFeedbackScoreData',
        selectedItems: [],
        multiSelect: true,
        columnDefs: [
            { field: 'EmpID', displayName: 'Employee ID' },
            { field: 'Employee_Name', displayName: 'Employee Name' },
            { field: 'Feedback_Date', displayName: 'Feedback Date' },
            { field: 'Score', displayName: 'Score' },
            { field: 'Comments', displayName: 'Comments' }
        ]

    };
    $scope.CBS_EmployeeBillingUtilizationGridOptions = {
        data: 'CBS_EmployeeBillingUtilizationData',
        selectedItems: [],
        multiSelect: true,
        columnDefs: [
            { field: 'EmpID', displayName: 'Employee ID' },
            { field: 'Employee_Name', displayName: 'Employee Name' },
            { field: 'From_Date', displayName: 'From Date' },
            { field: 'To_Date', displayName: 'To Date' },
            { field: 'Project', displayName: 'Project' },
            { field: 'Billing_Utilization', displayName: 'Billing Utilization' }
        ]

    };
    //$scope.CBS_EmployeesGridOptions = {    //    data: 'CBS_EmployeesData',
    //    selectedItems: [],
    //    multiSelect: true,
    //    columnDefs: [
    //        { field: 'EmpID', displayName: 'Employee ID' },
    //        { field: 'Employee_Name', displayName: 'Employee_Name' },
    //        { field: 'Designation', displayName: 'Designation' }
    //        { field: 'Date_Joined', displayName: 'Date_Joined' },
    //        { field: 'Career_Started_On', displayName: 'Career_Started_On' },
    //        { field: 'Appraisal_Score', displayName: 'Appraisal_Score' }
    //    ]
    //};
    $scope.CBS_EngagementGridOptions = {
        data: 'CBS_EngagementData',
        selectedItems: [],
        multiSelect: true,
        columnDefs: [
            { field: 'EmpID', displayName: 'Employee ID' },
            { field: 'Employee_Name', displayName: 'Employee Name' },
            { field: 'Date', displayName: 'Date' },
            { field: 'Event', displayName: 'Event' },
        ]

    };
    $scope.CBS_FuelAllowancesGridOptions = {
        data: 'CBS_FuelAllowancesData',
        selectedItems: [],
        multiSelect: true,
        columnDefs: [
            { field: 'EmpID', displayName: 'Employee ID' },
            { field: 'Employee_Name', displayName: 'Employee Name' },
            { field: 'Fueling_Date', displayName: 'Fueling Date' },
            { field: 'Number_Of_Liters', displayName: 'Number Of Liters' },
            { field: 'Amount', displayName: 'Amount' }
        ]

    };
    $scope.CBS_IncrementsGridOptions = {
        data: 'CBS_IncrementsData',
        selectedItems: [],
        multiSelect: true,
        columnDefs: [
            { field: 'EmpID', displayName: 'Employee ID' },
            { field: 'Employee_Name', displayName: 'Employee Name' },
            { field: 'Effective_Date', displayName: 'Effective Date' },
            { field: 'Increment_Amount', displayName: 'Increment Amount' }
        ]

    };
    $scope.CBS_MentorBuddyGridOptions = {
        data: 'CBS_MentorBuddyData',
        selectedItems: [],
        multiSelect: true,
        columnDefs: [
            { field: 'EmpID', displayName: 'Employee ID' },
            { field: 'Employee_Name', displayName: 'Employee Name' },
            { field: 'Date', displayName: 'Date' },
            { field: 'Mentor_or_Buddy_Type', displayName: 'Mentor or Buddy Type' },
            { field: 'Mentor_or_Buddy', displayName: 'Mentor or Buddy' }
        ]

    };
    $scope.CBS_PromotionsGridOptions = {
        data: 'CBS_PromotionsData',
        selectedItems: [],
        multiSelect: true,
        columnDefs: [
            { field: 'EmpID', displayName: 'Employee ID' },
            { field: 'Employee_Name', displayName: 'Employee Name' },
            { field: 'Date', displayName: 'Date' },
            { field: 'Promoted_To', displayName: 'Promoted To' },
            { field: 'Previous_Designation', displayName: 'Previous Designation' }
        ]

    };
    $scope.CBS_PublicAppearencesGridOptions = {
        data: 'CBS_PublicAppearencesData',
        selectedItems: [],
        multiSelect: true,
        columnDefs: [
            { field: 'EmpID', displayName: 'Employee ID' },
            { field: 'Employee_Name', displayName: 'Employee Name' },
            { field: 'Appearance_Date', displayName: 'Appearance Date' },
            { field: 'Location', displayName: 'Location' },
            { field: 'Event_Name', displayName: 'Event Name' },
            { field: 'Session_Topic', displayName: 'Session Topic' },
            { field: 'Number_Of_Participants', displayName: 'Number Of Participants' }
        ]

    };
    //$scope.CBS_ReportFormatGridOptions = {
    //    data: 'CBS_ReportFormatData',
    //    selectedItems: [],
    //    multiSelect: true,
    //    columnDefs: [
    //        { field: 'PriviledgeLevel', displayName: 'Priviledge Level' },
    //        { field: 'Section', displayName: 'Section' },
    //        { field: 'Enabled', displayName: 'Enabled' },
    //        { field: 'SectionCode', displayName: 'SectionCode' }
    //    ]

    //};
    $scope.CBS_TechnologyExposureGridOptions = {
        data: 'CBS_TechnologyExposureData',
        selectedItems: [],
        multiSelect: true,
        columnDefs: [
            { field: 'EmpID', displayName: 'Employee ID' },
            { field: 'Employee_Name', displayName: 'Employee Name' },
            { field: 'Date', displayName: 'Date' },
            { field: 'Engagement', displayName: 'Engagement' },
            { field: 'Technologies', displayName: 'Technologies' }
        ]

    };
    $scope.CBS_TrainingsGridOptions = {
        data: 'CBS_TrainingsData',
        selectedItems: [],
        multiSelect: true,
        columnDefs: [
            { field: 'EmpID', displayName: 'Employee ID' },
            { field: 'Employee_Name', displayName: 'Employee Name' },
            { field: 'Year', displayName: 'Year' },
            { field: 'Course_Name', displayName: 'Course Name' },
            { field: 'Training_Provider', displayName: 'Training Provider' },
            { field: 'External', displayName: 'External' },
            { field: 'Category', displayName: 'Category' },
            { field: 'Training_Month', displayName: 'Training Month' },
            { field: 'Time_Duration', displayName: 'Time Duration' },
            { field: 'Cost_Money', displayName: 'Cost' }
        ]

    };
    $scope.CBS_TravelsGridOptions = {
        data: 'CBS_TravelsData',
        selectedItems: [],
        multiSelect: true,
        columnDefs: [
            { field: 'EmpID', displayName: 'Employee ID' },
            { field: 'Employee_Name', displayName: 'Employee Name' },
            { field: 'Started_Date', displayName: 'Started Date' },
            { field: 'Number_Of_Days', displayName: 'Number Of Days' },
            { field: 'Country', displayName: 'Country' },
            { field: 'City', displayName: 'City' },
            { field: 'Allowance_In_SLR', displayName: 'Allowance In SLR' },
            { field: 'Purpose', displayName: 'Purpose' }
        ]

    };
    $scope.CBS_UniversitySessionsGridOptions = {
        data: 'CBS_UniversitySessionsData',
        selectedItems: [],
        multiSelect: true,
        columnDefs: [
            { field: 'EmpID', displayName: 'Employee ID' },
            { field: 'Employee_Name', displayName: 'Employee Name' },
            { field: 'Session_Date', displayName: 'Session Date' },
            { field: 'Initiated_By', displayName: 'Initiated By' },
            { field: 'Location', displayName: 'Location' },
            { field: 'Number_Of_Participants', displayName: 'Number Of Participants' },
            { field: 'Participants', displayName: 'Participants' },
            { field: 'Session_Type', displayName: 'Session Type' },
            { field: 'Time_Duration', displayName: 'Time Duration' },
            { field: 'Topic', displayName: 'Topic' },
            { field: 'To_the_University', displayName: 'To the University' }
        ]

    };

    $scope.CBS_ValueInnovationsGridOptions = {
        data: 'CBS_ValueInnovationsData',
        selectedItems: [],
        multiSelect: true,
        columnDefs: [
            { field: 'EmpID', displayName: 'Employee ID' },
            { field: 'Employee_Name', displayName: 'Employee Name' },
            { field: 'Innovation_Date', displayName: 'Innovation Date' },
            { field: 'Value_Innovation', displayName: 'Value Innovation' }
        ]

    };

    $scope.CBS_SalaryInformationsGridOptions = {
        data: 'CBS_SalaryInformationData',
        selectedItems: [],
        multiSelect: true,
        columnDefs: [
            { field: 'EmpID', displayName: 'Employee ID' },
            { field: 'Employee_Name', displayName: 'Employee Name' },
            { field: 'CurrentSalaryAmount', displayName: 'Current Salary Amount' },
            { field: 'Date', displayName: 'Date' },
            { field: 'EPF', displayName: 'EPF' },
            { field: 'ETF', displayName: 'ETF' }
        ]

    };

    $scope.CBS_AdditionalAccomplishmentsGridOptions = {
        data: 'CBS_AdditionalAccomplishmentsData',
        selectedItems: [],
        multiSelect: true,
        columnDefs: [
            { field: 'EmpID', displayName: 'Employee ID' },
            { field: 'Employee_Name', displayName: 'Employee Name' },
            { field: 'Accomplishment_Date', displayName: 'Accomplishments Date' },
            { field: 'AccomplishmentName', displayName: 'Accomplishment Name' }
        ]

    };

    $scope.CBS_BenefitsGridOptions = {
        data: 'CBS_BenefitsData',
        selectedItems: [],
        multiSelect: true,
        columnDefs: [
            { field: 'EmpID', displayName: 'Employee ID' },
            { field: 'Employee_Name', displayName: 'Employee Name' },
            { field: 'Date', displayName: 'Benefitted Date' },
            { field: 'Benefit_Name', displayName: 'Benefit Name' }
        ]

    };

    $scope.Approve = function (datatype) {
        var approved_ids = {
            datatype: datatype,
            ids: []
        };

        var selectedItems = [];

        switch (datatype) {
            case "CBS_Attendances":
                console.log("CBS_Attendances");
                selectedItems = $scope.CBS_AttendancesGridOptions.selectedItems;
                break;
            case "CBS_Awards":
                console.log("CBS_Awards");
                selectedItems = $scope.CBS_AwardsGridOptions.selectedItems;
                break;
            case "CBS_Bonuses":
                console.log("CBS_Bonuses");
                selectedItems = $scope.CBS_BonusesGridOptions.selectedItems;
                break;
            case "CBS_CustomerFeedbackScore":
                console.log("CBS_CustomerFeedbackScore");
                selectedItems = $scope.CBS_CustomerFeedbackScoreGridOptions.selectedItems;
                break;
            case "CBS_EmployeeBillingUtilization":
                console.log("CBS_EmployeeBillingUtilization");
                selectedItems = $scope.CBS_EmployeeBillingUtilizationGridOptions.selectedItems;
                break;

                //case "CBS_Employees":
                //    console.log("CBS_Employees");
                //    selectedItems = $scope.CBS_Employee.selectedItems;
                //    break;
            case "CBS_Engagement":
                console.log("CBS_Engagement");
                selectedItems = $scope.CBS_EngagementGridOptions.selectedItems;
                break;
            case "CBS_FuelAllowances":
                console.log("CBS_FuelAllowances");
                selectedItems = $scope.CBS_FuelAllowancesGridOptions.selectedItems;
                break;
            case "CBS_Increments":
                console.log("CBS_Increments");
                selectedItems = $scope.CBS_IncrementsGridOptions.selectedItems;
                break;
            case "CBS_MentorBuddy":
                console.log("CBS_MentorBuddy");
                selectedItems = $scope.CBS_MentorBuddyGridOptions.selectedItems;
                break;

            case "CBS_Promotions":
                console.log("CBS_Promotions");
                selectedItems = $scope.CBS_PromotionsGridOptions.selectedItems;
                break;
            case "CBS_PublicAppearences":
                console.log("CBS_PublicAppearences");
                selectedItems = $scope.CBS_PublicAppearencesGridOptions.selectedItems;
                break;
                //case "CBS_ReportFormat":
                //    console.log("CBS_ReportFormat");
                //    selectedItems = $scope.CBS_ReportFormat.selectedItems;
                //    break;
            case "CBS_TechnologyExposure":
                console.log("CBS_TechnologyExposure");
                selectedItems = $scope.CBS_TechnologyExposureGridOptions.selectedItems;
                break;
            case "CBS_Trainings":
                console.log("CBS_Trainings");
                selectedItems = $scope.CBS_TrainingsGridOptions.selectedItems;
                break;

            case "CBS_Travels":
                console.log("CBS_Travels");
                selectedItems = $scope.CBS_TravelsGridOptions.selectedItems;
                break;
            case "CBS_UniversitySessions":
                console.log("CBS_UniversitySessions");
                selectedItems = $scope.CBS_UniversitySessionsGridOptions.selectedItems;
                break;
            case "CBS_ValueInnovations":
                console.log("CBS_ValueInnovations");
                selectedItems = $scope.CBS_ValueInnovationsGridOptions.selectedItems;
                break;
            case "CBS_SalaryInformation":
                console.log("CBS_SalaryInformation");
                selectedItems = $scope.CBS_SalaryInformationsGridOptions.selectedItems;
                break;
            case "CBS_AdditionalAccomplishments":
                console.log("CBS_AdditionalAccomplishments");
                selectedItems = $scope.CBS_AdditionalAccomplishmentsGridOptions.selectedItems;
                break;
            case "CBS_Benefits":
                console.log("CBS_Benefits");
                selectedItems = $scope.CBS_BenefitsGridOptions.selectedItems;
                break;
        }

        angular.forEach(selectedItems, function (data, index) {
            approved_ids.ids.push({ "id": data.ID });
        });
        $http.post("/Admin/DataApprove/Approve/", approved_ids).
              success(function (data, status, headers, config) {
                  // this callback will be called asynchronously
                  // when the response is available
                  // alert(data);
                  switch (datatype) {
                      case "CBS_Attendances":
                          console.log("CBS_Attendances");
                          $scope.CBS_AttendancesData = data;
                          $scope.CBS_AttendancesGridOptions.selectedItems.length = 0
                         // alert($scope.CBS_AttendancesGridOptions.selectedItems);
                          break;
                      case "CBS_Awards":
                          console.log("CBS_Awards");
                          $scope.CBS_AwardsData = data;
                          $scope.CBS_AwardsGridOptions.selectedItems.length = 0
                          break;
                      case "CBS_Bonuses":
                          console.log("CBS_Bonuses");
                          $scope.CBS_BonusesData = data;
                          $scope.CBS_BonusesGridOptions.selectedItems.length = 0
                          break;
                      case "CBS_CustomerFeedbackScore":
                          console.log("CBS_CustomerFeedbackScore");
                          $scope.CBS_CustomerFeedbackScoreData = data;
                          $scope.CBS_CustomerFeedbackScoreGridOptions.selectedItems.length = 0
                          break;
                      case "CBS_EmployeeBillingUtilization":
                          console.log("CBS_EmployeeBillingUtilization");
                          $scope.CBS_EmployeeBillingUtilizationData = data;
                          $scope.CBS_EmployeeBillingUtilizationGridOptions.selectedItems.length = 0
                          break;

                          //case "CBS_Employees":
                          //    console.log("CBS_Employees");
                          //    $scope.CBS_Employee.selectedItems;
                          //    break;
                      case "CBS_Engagement":
                          console.log("CBS_Engagement");
                          $scope.CBS_EngagementData = data;
                          $scope.CBS_EngagementGridOptions.selectedItems.length = 0
                          break;
                      case "CBS_FuelAllowances":
                          console.log("CBS_FuelAllowances");
                          $scope.CBS_FuelAllowancesData = data;
                          $scope.CBS_FuelAllowancesGridOptions.selectedItems.length = 0
                          break;
                      case "CBS_Increments":
                          console.log("CBS_Increments");
                          $scope.CBS_IncrementsData = data;
                          $scope.CBS_IncrementsGridOptions.selectedItems.length = 0
                          break;
                      case "CBS_MentorBuddy":
                          console.log("CBS_MentorBuddy");
                          $scope.CBS_MentorBuddyData = data;
                          $scope.CBS_MentorBuddyGridOptions.selectedItems.length = 0
                          break;

                      case "CBS_Promotions":
                          console.log("CBS_Promotions");
                          $scope.CBS_PromotionsData = data;
                          $scope.CBS_PromotionsGridOptions.selectedItems.length = 0
                          break;
                      case "CBS_PublicAppearences":
                          console.log("CBS_PublicAppearences");
                          $scope.CBS_PublicAppearencesData = data;
                          $scope.CBS_PublicAppearencesGridOptions.selectedItems.length = 0
                          break;
                          //case "CBS_ReportFormat":
                          //    console.log("CBS_ReportFormat");
                          //    $scope.CBS_ReportFormat.selectedItems;
                          //    break;
                      case "CBS_TechnologyExposure":
                          console.log("CBS_TechnologyExposure");
                          $scope.CBS_TechnologyExposureData = data;
                          $scope.CBS_TechnologyExposureGridOptions.selectedItems.length = 0
                          break;
                      case "CBS_Trainings":
                          console.log("CBS_Trainings");
                          $scope.CBS_TrainingsData = data;
                          $scope.CBS_TrainingsGridOptions.selectedItems.length = 0
                          break;

                      case "CBS_Travels":
                          console.log("CBS_Travels");
                          $scope.CBS_TravelsData = data;
                          $scope.CBS_TravelsGridOptions.selectedItems.length = 0
                          break;
                      case "CBS_UniversitySessions":
                          console.log("CBS_UniversitySessions");
                          $scope.CBS_UniversitySessionsData = data;
                          $scope.CBS_TravelsGridOptions.selectedItems;
                          $scope.CBS_UniversitySessionsGridOptions.selectedItems.length = 0
                          break;
                      case "CBS_ValueInnovations":
                          console.log("CBS_ValueInnovations");
                          $scope.CBS_ValueInnovationsData = data;
                          $scope.CBS_ValueInnovationsGridOptions.selectedItems.length = 0
                          break;
                      case "CBS_SalaryInformation":
                          console.log("CBS_SalaryInformation");
                          $scope.CBS_SalaryInformationData = data;
                          $scope.CBS_SalaryInformationsGridOptions.selectedItems.length = 0
                          break;
                      case "CBS_AdditionalAccomplishments":
                          console.log("CBS_AdditionalAccomplishments");
                          $scope.CBS_AdditionalAccomplishmentsData = data;
                          $scope.CBS_AdditionalAccomplishmentsGridOptions.selectedItems.length = 0
                          break;
                      case "CBS_Benefits":
                          console.log("CBS_Benefits");
                          $scope.CBS_BenefitsData = data;
                          $scope.CBS_BenefitsGridOptions.selectedItems.length = 0
                          break;
                  }
              }).
              error(function (data, status, headers, config) {
                  // called asynchronously if an error occurs
                  // or server returns response with an error status.
              });
    };

    $scope.Discard = function (datatype) {
        var approved_ids = {
            datatype: datatype,
            ids: []
        };

        var selectedItems = [];

        switch (datatype) {
            case "CBS_Attendances":
                console.log("CBS_Attendances");
                selectedItems = $scope.CBS_AttendancesGridOptions.selectedItems;
                break;
            case "CBS_Awards":
                console.log("CBS_Awards");
                selectedItems = $scope.CBS_AwardsGridOptions.selectedItems;
                break;
            case "CBS_Bonuses":
                console.log("CBS_Bonuses");
                selectedItems = $scope.CBS_BonusesGridOptions.selectedItems;
                break;
            case "CBS_CustomerFeedbackScore":
                console.log("CBS_CustomerFeedbackScore");
                selectedItems = $scope.CBS_CustomerFeedbackScoreGridOptions.selectedItems;
                break;
            case "CBS_EmployeeBillingUtilization":
                console.log("CBS_EmployeeBillingUtilization");
                selectedItems = $scope.CBS_EmployeeBillingUtilizationGridOptions.selectedItems;
                break;

                //case "CBS_Employees":
                //    console.log("CBS_Employees");
                //    selectedItems = $scope.CBS_Employee.selectedItems;
                //    break;
            case "CBS_Engagement":
                console.log("CBS_Engagement");
                selectedItems = $scope.CBS_EngagementGridOptions.selectedItems;
                break;
            case "CBS_FuelAllowances":
                console.log("CBS_FuelAllowances");
                selectedItems = $scope.CBS_FuelAllowancesGridOptions.selectedItems;
                break;
            case "CBS_Increments":
                console.log("CBS_Increments");
                selectedItems = $scope.CBS_IncrementsGridOptions.selectedItems;
                break;
            case "CBS_MentorBuddy":
                console.log("CBS_MentorBuddy");
                selectedItems = $scope.CBS_MentorBuddyGridOptions.selectedItems;
                break;

            case "CBS_Promotions":
                console.log("CBS_Promotions");
                selectedItems = $scope.CBS_PromotionsGridOptions.selectedItems;
                break;
            case "CBS_PublicAppearences":
                console.log("CBS_PublicAppearences");
                selectedItems = $scope.CBS_PublicAppearencesGridOptions.selectedItems;
                break;
                //case "CBS_ReportFormat":
                //    console.log("CBS_ReportFormat");
                //    selectedItems = $scope.CBS_ReportFormat.selectedItems;
                //    break;
            case "CBS_TechnologyExposure":
                console.log("CBS_TechnologyExposure");
                selectedItems = $scope.CBS_TechnologyExposureGridOptions.selectedItems;
                break;
            case "CBS_Trainings":
                console.log("CBS_Trainings");
                selectedItems = $scope.CBS_TrainingsGridOptions.selectedItems;
                break;

            case "CBS_Travels":
                console.log("CBS_Travels");
                selectedItems = $scope.CBS_TravelsGridOptions.selectedItems;
                break;
            case "CBS_UniversitySessions":
                console.log("CBS_UniversitySessions");
                selectedItems = $scope.CBS_UniversitySessionsGridOptions.selectedItems;
                break;
            case "CBS_ValueInnovations":
                console.log("CBS_ValueInnovations");
                selectedItems = $scope.CBS_ValueInnovationsGridOptions.selectedItems;
                break;
            case "CBS_SalaryInformation":
                console.log("CBS_SalaryInformation");
                selectedItems = $scope.CBS_SalaryInformationsGridOptions.selectedItems;
                break;
            case "CBS_AdditionalAccomplishments":
                console.log("CBS_AdditionalAccomplishments");
                selectedItems = $scope.CBS_AdditionalAccomplishmentsGridOptions.selectedItems;
                break;
            case "CBS_Benefits":
                console.log("CBS_Benefits");
                selectedItems = $scope.CBS_BenefitsGridOptions.selectedItems;
                break;
        }

        angular.forEach(selectedItems, function (data, index) {
            approved_ids.ids.push({ "id": data.ID });
        });
        $http.post("/Admin/DataApprove/Discard/", approved_ids).
              success(function (data, status, headers, config) {
                  // this callback will be called asynchronously
                  // when the response is available
                  // alert(data);
                  switch (datatype) {
                      case "CBS_Attendances":
                          console.log("CBS_Attendances");
                          $scope.CBS_AttendancesData = data;
                          $scope.CBS_AttendancesGridOptions.selectedItems.length = 0
                          // alert($scope.CBS_AttendancesGridOptions.selectedItems);
                          break;
                      case "CBS_Awards":
                          console.log("CBS_Awards");
                          $scope.CBS_AwardsData = data;
                          $scope.CBS_AwardsGridOptions.selectedItems.length = 0
                          break;
                      case "CBS_Bonuses":
                          console.log("CBS_Bonuses");
                          $scope.CBS_BonusesData = data;
                          $scope.CBS_BonusesGridOptions.selectedItems.length = 0
                          break;
                      case "CBS_CustomerFeedbackScore":
                          console.log("CBS_CustomerFeedbackScore");
                          $scope.CBS_CustomerFeedbackScoreData = data;
                          $scope.CBS_CustomerFeedbackScoreGridOptions.selectedItems.length = 0
                          break;
                      case "CBS_EmployeeBillingUtilization":
                          console.log("CBS_EmployeeBillingUtilization");
                          $scope.CBS_EmployeeBillingUtilizationData = data;
                          $scope.CBS_EmployeeBillingUtilizationGridOptions.selectedItems.length = 0
                          break;

                          //case "CBS_Employees":
                          //    console.log("CBS_Employees");
                          //    $scope.CBS_Employee.selectedItems;
                          //    break;
                      case "CBS_Engagement":
                          console.log("CBS_Engagement");
                          $scope.CBS_EngagementData = data;
                          $scope.CBS_EngagementGridOptions.selectedItems.length = 0
                          break;
                      case "CBS_FuelAllowances":
                          console.log("CBS_FuelAllowances");
                          $scope.CBS_FuelAllowancesData = data;
                          $scope.CBS_FuelAllowancesGridOptions.selectedItems.length = 0
                          break;
                      case "CBS_Increments":
                          console.log("CBS_Increments");
                          $scope.CBS_IncrementsData = data;
                          $scope.CBS_IncrementsGridOptions.selectedItems.length = 0
                          break;
                      case "CBS_MentorBuddy":
                          console.log("CBS_MentorBuddy");
                          $scope.CBS_MentorBuddyData = data;
                          $scope.CBS_MentorBuddyGridOptions.selectedItems.length = 0
                          break;

                      case "CBS_Promotions":
                          console.log("CBS_Promotions");
                          $scope.CBS_PromotionsData = data;
                          $scope.CBS_PromotionsGridOptions.selectedItems.length = 0
                          break;
                      case "CBS_PublicAppearences":
                          console.log("CBS_PublicAppearences");
                          $scope.CBS_PublicAppearencesData = data;
                          $scope.CBS_PublicAppearencesGridOptions.selectedItems.length = 0
                          break;
                          //case "CBS_ReportFormat":
                          //    console.log("CBS_ReportFormat");
                          //    $scope.CBS_ReportFormat.selectedItems;
                          //    break;
                      case "CBS_TechnologyExposure":
                          console.log("CBS_TechnologyExposure");
                          $scope.CBS_TechnologyExposureData = data;
                          $scope.CBS_TechnologyExposureGridOptions.selectedItems.length = 0
                          break;
                      case "CBS_Trainings":
                          console.log("CBS_Trainings");
                          $scope.CBS_TrainingsData = data;
                          $scope.CBS_TrainingsGridOptions.selectedItems.length = 0
                          break;

                      case "CBS_Travels":
                          console.log("CBS_Travels");
                          $scope.CBS_TravelsData = data;
                          $scope.CBS_TravelsGridOptions.selectedItems.length = 0
                          break;
                      case "CBS_UniversitySessions":
                          console.log("CBS_UniversitySessions");
                          $scope.CBS_UniversitySessionsData = data;
                          $scope.CBS_TravelsGridOptions.selectedItems;
                          $scope.CBS_UniversitySessionsGridOptions.selectedItems.length = 0
                          break;
                      case "CBS_ValueInnovations":
                          console.log("CBS_ValueInnovations");
                          $scope.CBS_ValueInnovationsData = data;
                          $scope.CBS_ValueInnovationsGridOptions.selectedItems.length = 0
                          break;
                      case "CBS_SalaryInformation":
                          console.log("CBS_SalaryInformation");
                          $scope.CBS_SalaryInformationData = data;
                          $scope.CBS_SalaryInformationsGridOptions.selectedItems.length = 0
                          break;
                      case "CBS_AdditionalAccomplishments":
                          console.log("CBS_AdditionalAccomplishments");
                          $scope.CBS_AdditionalAccomplishmentsData = data;
                          $scope.CBS_AdditionalAccomplishmentsGridOptions.selectedItems.length = 0
                          break;
                      case "CBS_Benefits":
                          console.log("CBS_Benefits");
                          $scope.CBS_BenefitsData = data;
                          $scope.CBS_BenefitsGridOptions.selectedItems.length = 0
                          break;
                  }
              }).
              error(function (data, status, headers, config) {
                  // called asynchronously if an error occurs
                  // or server returns response with an error status.
              });
    };

});