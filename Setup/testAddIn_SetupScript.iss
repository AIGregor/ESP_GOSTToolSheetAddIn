; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Esprit Test ADD-In"
#define MyAppVersion "0.3 with test messages"
#define MyAppPublisher "LO CNITI."
#define MyAppURL "http://www.locniti.ru//"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{84BF1727-5700-449D-8DF0-71678398EEF8}}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName=C:\Program Files (x86)\D.P.Technology\ESPRIT\AddIns\{#MyAppName}
DefaultGroupName=DP Technology\ESPRIT\Add-Ins\Esprit Test ADD-In
AllowNoIcons=yes
OutputDir=E:\APIEsprit\ESPRITLibraryADDINKDB\Setup\
OutputBaseFilename=Esprit AddIn Setup ({#MyAppVersion})
SetupIconFile=E:\APIEsprit\ESPRITLibraryADDINKDB\Setup\ESPRIT.ico
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"

[Files]
Source: "E:\APIEsprit\ESPRITLibraryADDINKDB\ESPRITLibraryADDIN\bin\Debug\ESPRITLibraryADDIN.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\APIEsprit\ESPRITLibraryADDINKDB\ESPRITLibraryADDIN\bin\Debug\ESPRITLibraryADDIN.reg"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\APIEsprit\ESPRITLibraryADDINKDB\ESPRITLibraryADDIN\bin\Debug\ESPRITLibraryADDIN.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\APIEsprit\ESPRITLibraryADDINKDB\ESPRITLibraryADDIN\bin\Debug\ESPRITLibraryADDIN.tlb"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\APIEsprit\ESPRITLibraryADDINKDB\ESPRITLibraryADDIN\bin\Debug\ESPRITLibraryADDIN.dll.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\APIEsprit\ESPRITLibraryADDINKDB\ESPRITLibraryADDIN\bin\Debug\ServerName.xml"; DestDir: "C:\Program Files (x86)\D.P.Technology\ESPRIT\Prog"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"

; �������� ������� � �������� 
[Registry]
Root: HKLM; Subkey:"Software\Wow6432Node\D.P.Technology\esprit\AddIns\ESPRITLibraryADDIN.Connect"; ValueType: string; ValueName: "Description"; ValueData: "�������� ���������� ��� ESPRIT. ����: ��������� ������ � ���� ������. ���� �������� 27.03.2017"; 
Root: HKLM; Subkey:"Software\Wow6432Node\D.P.Technology\esprit\AddIns\ESPRITLibraryADDIN.Connect"; ValueType: string; ValueName: "FriendlyName"; ValueData: "ESPRIT ��� ������ - ����� �������";  
Root: HKLM; Subkey:"Software\Wow6432Node\D.P.Technology\esprit\AddIns\ESPRITLibraryADDIN.Connect"; ValueType: dword; ValueName: "LoadBehavior"; ValueData: "00000001"; 

[Run]
Filename:"{reg:HKLM\SOFTWARE\Microsoft\.NETFramework,InstallRoot}\v4.0.30319\RegAsm.exe"; Parameters: ESPRITLibraryADDIN.dll /codebase /tlb; WorkingDir: {app}; StatusMsg: "Registering controls ..."; Flags: runhidden;

[UninstallRun]
Filename:"{reg:HKLM\SOFTWARE\Microsoft\.NETFramework,InstallRoot}\v4.0.30319\RegAsm.exe"; Parameters: ESPRITLibraryADDIN.dll /unregister; WorkingDir: {app}; StatusMsg: "Unregistering controls ..."; Flags: runhidden;
