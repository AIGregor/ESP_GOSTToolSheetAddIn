; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "GOSTSetupSheets"
#define MyAppVersion "0.82 log"
#define MyAppPublisher "LO CNITI"
#define MyAppURL "http://www.locniti.ru//"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{F2F24518-01DA-4929-9A45-BD6032717C2D}}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName=C:\Program Files (x86)\D.P.Technology\ESPRIT\AddIns\{#MyAppName}
DefaultGroupName=DP Technology\ESPRIT\Add-Ins\����� ������� ����������� (����)
AllowNoIcons=yes
OutputDir=E:\APIEsprit\ESPGOST\Setup
OutputBaseFilename= ESPRIT GOST Sheet Setup ({#MyAppVersion})
SetupIconFile=E:\APIEsprit\ESPGOST\Setup\ESPRIT.ico
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"

[Files]

Source: "E:\APIEsprit\ESPGOST\Setup\RegAddIn.reg"; DestDir: "{app}"; Flags: ignoreversion

Source: "E:\APIEsprit\ESPGOST\ESP_GOSTToolSheetAddIn\bin\Release\ESP_GOSTToolSheetAddIn.dll"; DestDir: "{app}"; Flags: ignoreversion

Source: "E:\APIEsprit\ESPGOST\ESP_GOSTToolSheetAddIn\bin\Release\Resources\AddinSettings.xml"; DestDir: "{app}\Resources"; Flags: ignoreversion

Source: "E:\APIEsprit\ESPGOST\ESP_GOSTToolSheetAddIn\bin\Release\Resources\F4.xlsx"; DestDir: "{app}\Resources"; Flags: ignoreversion

Source: "E:\APIEsprit\ESPGOST\ESP_GOSTToolSheetAddIn\bin\Release\Resources\lic.eal"; DestDir: "{app}\Resources"; Flags: ignoreversion

Source: "E:\APIEsprit\ESPGOST\ESP_GOSTToolSheetAddIn\bin\Release\Resources\ToolName.txt"; DestDir: "{app}\Resources"; Flags: ignoreversion

Source: "E:\APIEsprit\ESPGOST\ESP_GOSTToolSheetAddIn\bin\Release\Resources\FontsGOSTtypeB.ttf"; DestDir: "{fonts}"; FontInstall: "GOST type B"; Flags: onlyifdoesntexist uninsneveruninstall
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"

; �������� ������� � �������� 
[Registry]
Root: HKLM; Subkey:"Software\Wow6432Node\D.P.Technology\esprit\AddIns\ESP_GOSTToolSheetAddIn.Connect"; ValueType: string; ValueName: "Description"; ValueData: "�������������� ������������ ����� ������� �� ���� 3.1404-86 � ������� ����� EXCEL"; 
Root: HKLM; Subkey:"Software\Wow6432Node\D.P.Technology\esprit\AddIns\ESP_GOSTToolSheetAddIn.Connect"; ValueType: string; ValueName: "FriendlyName"; ValueData: "���� - ����� ������� �����������";  
Root: HKLM; Subkey:"Software\Wow6432Node\D.P.Technology\esprit\AddIns\ESP_GOSTToolSheetAddIn.Connect"; ValueType: dword; ValueName: "LoadBehavior"; ValueData: "00000001"; 

[Run]
Filename:"{reg:HKLM\SOFTWARE\Microsoft\.NETFramework,InstallRoot}\v4.0.30319\RegAsm.exe"; Parameters: ESP_GOSTToolSheetAddIn.dll /codebase /tlb; WorkingDir: {app}; StatusMsg: "Registering controls ..."; Flags: runhidden

[UninstallRun]
Filename:"{reg:HKLM\SOFTWARE\Microsoft\.NETFramework,InstallRoot}\v4.0.30319\RegAsm.exe"; Parameters: ESP_GOSTToolSheetAddIn.dll /unregister; WorkingDir: {app}; StatusMsg: "Unregistering controls ...";  Flags: runhidden
