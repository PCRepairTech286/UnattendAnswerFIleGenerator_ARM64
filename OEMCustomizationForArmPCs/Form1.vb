Imports System.Drawing.Text
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms.VisualStyles

Public Class MainForm
    Private ReadOnly HideLocalAccountScreen As String = "false"
    Public Sub CreateUnattend(targetName As String)
        Dim UWPAppsUseLightTheme As String
        Dim SystemUsesLightTheme As String
        Dim SkipMachineOOBE As String
        Dim SkipUserOOBE As String
        Dim ConfigureChatAutoInstall As String
        Dim WindowsSpotlight As String
        Dim HelpCustomized As String
        Dim HideEULAPage As String
        Dim HideOEMRegistrationScreen As String
        Dim HideOnlineAccountScreens As String
        Dim HideWirelessSetupInOOBE As String
        Dim UnattendEnableRetailDemo As String
        Dim RequiresUserInput As String
        Dim AutoLogon_Enabled As String

        ' Set Light/Dark Mode Variables
        If cmbLightOrDarkMode.SelectedItem.ToString() = "Dark" Then
            UWPAppsUseLightTheme = "false"
            SystemUsesLightTheme = "false"
        Else
            UWPAppsUseLightTheme = "true"
            SystemUsesLightTheme = "true"
        End If
        ' Convert Booleans to Strings
        Select Case chkSkipOOBE.Checked
            Case True
                SkipMachineOOBE = "true"
                SkipUserOOBE = "true"
            Case False
                SkipMachineOOBE = "false"
                SkipUserOOBE = "false"
        End Select
        Select Case chkConfigureChatAutoInstall.Checked
            Case True
                ConfigureChatAutoInstall = "true"
            Case False
                ConfigureChatAutoInstall = "false"
        End Select
        Select Case chkWindowsSpotlight.Checked
            Case True
                WindowsSpotlight = "true"
            Case False
                WindowsSpotlight = "false"
        End Select
        Select Case chkHelpCustomized.Checked
            Case True
                HelpCustomized = "true"
            Case False
                HelpCustomized = "false"
        End Select
        Select Case chkHideEULAPage.Checked
            Case True
                HideEULAPage = "true"
            Case False
                HideEULAPage = "false"
        End Select
        Select Case chkHideOEMRegistrationScreen.Checked
            Case True
                HideOEMRegistrationScreen = "true"
            Case False
                HideOEMRegistrationScreen = "false"
        End Select
        Select Case chkHideOnlineAccountScreens.Checked
            Case True
                HideOnlineAccountScreens = "true"
            Case False
                HideOnlineAccountScreens = "false"
        End Select
        Select Case chkHideWirelessSetupInOOBE.Checked
            Case True
                HideWirelessSetupInOOBE = "true"
            Case False
                HideWirelessSetupInOOBE = "false"
        End Select
        Select Case chkUnattendEnableRetailDemo.Checked
            Case True
                UnattendEnableRetailDemo = "true"
            Case False
                UnattendEnableRetailDemo = "false"
        End Select
        Select Case chkRequiresUserInput.Checked
            Case True
                RequiresUserInput = "true"
            Case False
                RequiresUserInput = "false"
        End Select
        Select Case chkAutoLogon.Checked
            Case True
                AutoLogon_Enabled = "true"
            Case False
                AutoLogon_Enabled = "false"
        End Select
        'All values now set, now time to create.
        Try
            Dim document As XDocument
            If chkRunCommands.Checked = True Then
                If chkSkipOOBE.Checked = True Then
                    document = <?xml version="1.0" encoding="UTF-8"?>
                               <unattend xmlns="urn:schemas-microsoft-com:unattend">
                                   <settings pass="specialize">
                                       <component name="Microsoft-Windows-Deployment" processorArchitecture="arm64" publicKeyToken="31bf3856ad364e35" language="neutral" versionScope="nonSxS" xmlns:wcm="http://schemas.microsoft.com/WMIConfig/2002/State" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
                                           <RunSynchronous>
                                               <RunSynchronousCommand wcm:action="add">
                                                   <Path><%= txtCommandDuringSpecializePhase.Text %></Path>
                                                   <Order>1</Order>
                                                   <WillReboot>Never</WillReboot>
                                               </RunSynchronousCommand>
                                           </RunSynchronous>
                                       </component>
                                       <component name="Microsoft-Windows-International-Core" processorArchitecture="arm64" publicKeyToken="31bf3856ad364e35" language="neutral" versionScope="nonSxS" xmlns:wcm="http://schemas.microsoft.com/WMIConfig/2002/State" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
                                           <InputLocale><%= txtInputLocale.Text %></InputLocale>
                                           <SystemLocale><%= txtSystemLocale.Text %></SystemLocale>
                                           <UILanguage><%= txtUILanguage.Text %></UILanguage>
                                           <UILanguageFallback>en-US</UILanguageFallback>
                                           <UserLocale><%= txtUserLocale.Text %></UserLocale>
                                       </component>
                                       <component name="Microsoft-Windows-Shell-Setup" processorArchitecture="arm64" publicKeyToken="31bf3856ad364e35" language="neutral" versionScope="nonSxS" xmlns:wcm="http://schemas.microsoft.com/WMIConfig/2002/State" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
                                           <OEMInformation>
                                               <Logo><%= txtLogo.Text %></Logo>
                                               <Manufacturer><%= txtManufacturer.Text %></Manufacturer>
                                               <HelpCustomized><%= HelpCustomized %></HelpCustomized>
                                               <Model><%= txtModel.Text %></Model>
                                               <RecycleURL><%= txtRecycleURL.Text %></RecycleURL>
                                               <SupportAppURL><%= txtSupportAppURL.Text %></SupportAppURL>
                                               <SupportHours><%= txtSupportHours.Text %></SupportHours>
                                               <SupportPhone><%= txtSupportPhone.Text %></SupportPhone>
                                               <SupportProvider><%= txtSupportProvider.Text %></SupportProvider>
                                               <SupportURL><%= txtSupportURL.Text %></SupportURL>
                                               <TradeInURL><%= txtTradeInURL.Text %></TradeInURL>
                                           </OEMInformation>
                                           <Themes>
                                               <WindowsSpotlight><%= WindowsSpotlight %></WindowsSpotlight>
                                               <UWPAppsUseLightTheme><%= UWPAppsUseLightTheme %></UWPAppsUseLightTheme>
                                               <SystemUsesLightTheme><%= SystemUsesLightTheme %></SystemUsesLightTheme>
                                               <DesktopBackground><%= txtDesktopBackground.Text %></DesktopBackground>
                                               <ThemeName><%= txtThemeName.Text %></ThemeName>
                                           </Themes>
                                           <ProductKey><%= txtProductKey.Text %></ProductKey>
                                           <OEMName><%= txtOEMName.Text %></OEMName>
                                           <TimeZone><%= txtTimeZone.Text %></TimeZone>
                                           <ComputerName><%= txtComputerName.Text %></ComputerName>
                                           <RegisteredOwner><%= txtRegisteredOwner.Text %></RegisteredOwner>
                                           <ConfigureChatAutoInstall><%= ConfigureChatAutoInstall %></ConfigureChatAutoInstall>
                                       </component>
                                   </settings>
                                   <settings pass="oobeSystem">
                                       <component name="Microsoft-Windows-Shell-Setup" processorArchitecture="arm64" publicKeyToken="31bf3856ad364e35" language="neutral" versionScope="nonSxS" xmlns:wcm="http://schemas.microsoft.com/WMIConfig/2002/State" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
                                           <FirstLogonCommands>
                                               <SynchronousCommand wcm:action="add">
                                                   <Order>1</Order>
                                                   <CommandLine><%= txtFirstLogonCommand.Text %></CommandLine>
                                                   <RequiresUserInput><%= RequiresUserInput %></RequiresUserInput>
                                               </SynchronousCommand>
                                           </FirstLogonCommands>
                                           <OOBE>
                                               <HideEULAPage><%= HideEULAPage %></HideEULAPage>
                                               <HideLocalAccountScreen><%= HideLocalAccountScreen %></HideLocalAccountScreen>
                                               <HideOEMRegistrationScreen><%= HideOEMRegistrationScreen %></HideOEMRegistrationScreen>
                                               <HideOnlineAccountScreens><%= HideOnlineAccountScreens %></HideOnlineAccountScreens>
                                               <HideWirelessSetupInOOBE><%= HideWirelessSetupInOOBE %></HideWirelessSetupInOOBE>
                                               <OEMAppId><%= txtOEMAppId.Text %></OEMAppId>
                                               <UnattendEnableRetailDemo><%= UnattendEnableRetailDemo %></UnattendEnableRetailDemo>
                                               <SkipMachineOOBE><%= SkipMachineOOBE %></SkipMachineOOBE>
                                               <SkipUserOOBE><%= SkipUserOOBE %></SkipUserOOBE>
                                           </OOBE>
                                           <UserAccounts>
                                               <LocalAccounts>
                                                   <LocalAccount wcm:action="add">
                                                       <DisplayName><%= txtAdminDisplayName.Text %></DisplayName>
                                                       <Name><%= txtAdminName.Text %></Name>
                                                       <Group>Administrators</Group>
                                                       <Password>
                                                           <Value><%= txtAdminPassword.Text %></Value>
                                                           <PlainText>true</PlainText>
                                                       </Password>
                                                   </LocalAccount>
                                               </LocalAccounts>
                                           </UserAccounts>
                                           <AutoLogon>
                                               <Password>
                                                   <Value><%= txtAdminPassword.Text %></Value>
                                                   <PlainText>true</PlainText>
                                               </Password>
                                               <Enabled><%= AutoLogon_Enabled %></Enabled>
                                               <Username><%= txtAdminName.Text %></Username>
                                           </AutoLogon>
                                       </component>
                                   </settings>
                               </unattend>

                Else
                    document = <?xml version="1.0" encoding="UTF-8"?>
                               <unattend xmlns="urn:schemas-microsoft-com:unattend">
                                   <settings pass="specialize">
                                       <component name="Microsoft-Windows-Deployment" processorArchitecture="arm64" publicKeyToken="31bf3856ad364e35" language="neutral" versionScope="nonSxS" xmlns:wcm="http://schemas.microsoft.com/WMIConfig/2002/State" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
                                           <RunSynchronous>
                                               <RunSynchronousCommand wcm:action="add">
                                                   <Path><%= txtCommandDuringSpecializePhase.Text %></Path>
                                                   <Order>1</Order>
                                                   <WillReboot>Never</WillReboot>
                                               </RunSynchronousCommand>
                                           </RunSynchronous>
                                       </component>
                                       <component name="Microsoft-Windows-International-Core" processorArchitecture="arm64" publicKeyToken="31bf3856ad364e35" language="neutral" versionScope="nonSxS" xmlns:wcm="http://schemas.microsoft.com/WMIConfig/2002/State" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
                                           <InputLocale><%= txtInputLocale.Text %></InputLocale>
                                           <SystemLocale><%= txtSystemLocale.Text %></SystemLocale>
                                           <UILanguage><%= txtUILanguage.Text %></UILanguage>
                                           <UILanguageFallback>en-US</UILanguageFallback>
                                           <UserLocale><%= txtUserLocale.Text %></UserLocale>
                                       </component>
                                       <component name="Microsoft-Windows-Shell-Setup" processorArchitecture="arm64" publicKeyToken="31bf3856ad364e35" language="neutral" versionScope="nonSxS" xmlns:wcm="http://schemas.microsoft.com/WMIConfig/2002/State" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
                                           <OEMInformation>
                                               <Logo><%= txtLogo.Text %></Logo>
                                               <Manufacturer><%= txtManufacturer.Text %></Manufacturer>
                                               <HelpCustomized><%= HelpCustomized %></HelpCustomized>
                                               <Model><%= txtModel.Text %></Model>
                                               <RecycleURL><%= txtRecycleURL.Text %></RecycleURL>
                                               <SupportAppURL><%= txtSupportAppURL.Text %></SupportAppURL>
                                               <SupportHours><%= txtSupportHours.Text %></SupportHours>
                                               <SupportPhone><%= txtSupportPhone.Text %></SupportPhone>
                                               <SupportProvider><%= txtSupportProvider.Text %></SupportProvider>
                                               <SupportURL><%= txtSupportURL.Text %></SupportURL>
                                               <TradeInURL><%= txtTradeInURL.Text %></TradeInURL>
                                           </OEMInformation>
                                           <Themes>
                                               <WindowsSpotlight><%= WindowsSpotlight %></WindowsSpotlight>
                                               <UWPAppsUseLightTheme><%= UWPAppsUseLightTheme %></UWPAppsUseLightTheme>
                                               <SystemUsesLightTheme><%= SystemUsesLightTheme %></SystemUsesLightTheme>
                                               <DesktopBackground><%= txtDesktopBackground.Text %></DesktopBackground>
                                               <ThemeName><%= txtThemeName.Text %></ThemeName>
                                           </Themes>
                                           <ProductKey><%= txtProductKey.Text %></ProductKey>
                                           <OEMName><%= txtOEMName.Text %></OEMName>
                                           <TimeZone><%= txtTimeZone.Text %></TimeZone>
                                           <ComputerName><%= txtComputerName.Text %></ComputerName>
                                           <RegisteredOwner><%= txtRegisteredOwner.Text %></RegisteredOwner>
                                           <ConfigureChatAutoInstall><%= ConfigureChatAutoInstall %></ConfigureChatAutoInstall>
                                       </component>
                                   </settings>
                                   <settings pass="oobeSystem">
                                       <component name="Microsoft-Windows-Shell-Setup" processorArchitecture="arm64" publicKeyToken="31bf3856ad364e35" language="neutral" versionScope="nonSxS" xmlns:wcm="http://schemas.microsoft.com/WMIConfig/2002/State" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
                                           <FirstLogonCommands>
                                               <SynchronousCommand wcm:action="add">
                                                   <Order>1</Order>
                                                   <CommandLine><%= txtFirstLogonCommand.Text %></CommandLine>
                                                   <RequiresUserInput><%= RequiresUserInput %></RequiresUserInput>
                                               </SynchronousCommand>
                                           </FirstLogonCommands>
                                           <OOBE>
                                               <HideEULAPage><%= HideEULAPage %></HideEULAPage>
                                               <HideLocalAccountScreen><%= HideLocalAccountScreen %></HideLocalAccountScreen>
                                               <HideOEMRegistrationScreen><%= HideOEMRegistrationScreen %></HideOEMRegistrationScreen>
                                               <HideOnlineAccountScreens><%= HideOnlineAccountScreens %></HideOnlineAccountScreens>
                                               <HideWirelessSetupInOOBE><%= HideWirelessSetupInOOBE %></HideWirelessSetupInOOBE>
                                               <OEMAppId><%= txtOEMAppId.Text %></OEMAppId>
                                               <UnattendEnableRetailDemo><%= UnattendEnableRetailDemo %></UnattendEnableRetailDemo>
                                               <SkipMachineOOBE><%= SkipMachineOOBE %></SkipMachineOOBE>
                                               <SkipUserOOBE><%= SkipUserOOBE %></SkipUserOOBE>
                                           </OOBE>
                                       </component>
                                   </settings>
                               </unattend>
                End If
            Else
                If chkSkipOOBE.Checked = True Then
                    document = <?xml version="1.0" encoding="UTF-8"?>
                               <unattend xmlns="urn:schemas-microsoft-com:unattend">
                                   <settings pass="specialize">
                                       <component name="Microsoft-Windows-International-Core" processorArchitecture="arm64" publicKeyToken="31bf3856ad364e35" language="neutral" versionScope="nonSxS" xmlns:wcm="http://schemas.microsoft.com/WMIConfig/2002/State" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
                                           <InputLocale><%= txtInputLocale.Text %></InputLocale>
                                           <SystemLocale><%= txtSystemLocale.Text %></SystemLocale>
                                           <UILanguage><%= txtUILanguage.Text %></UILanguage>
                                           <UILanguageFallback>en-US</UILanguageFallback>
                                           <UserLocale><%= txtUserLocale.Text %></UserLocale>
                                       </component>
                                       <component name="Microsoft-Windows-Shell-Setup" processorArchitecture="arm64" publicKeyToken="31bf3856ad364e35" language="neutral" versionScope="nonSxS" xmlns:wcm="http://schemas.microsoft.com/WMIConfig/2002/State" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
                                           <OEMInformation>
                                               <Logo><%= txtLogo.Text %></Logo>
                                               <Manufacturer><%= txtManufacturer.Text %></Manufacturer>
                                               <HelpCustomized><%= HelpCustomized %></HelpCustomized>
                                               <Model><%= txtModel.Text %></Model>
                                               <RecycleURL><%= txtRecycleURL.Text %></RecycleURL>
                                               <SupportAppURL><%= txtSupportAppURL.Text %></SupportAppURL>
                                               <SupportHours><%= txtSupportHours.Text %></SupportHours>
                                               <SupportPhone><%= txtSupportPhone.Text %></SupportPhone>
                                               <SupportProvider><%= txtSupportProvider.Text %></SupportProvider>
                                               <SupportURL><%= txtSupportURL.Text %></SupportURL>
                                               <TradeInURL><%= txtTradeInURL.Text %></TradeInURL>
                                           </OEMInformation>
                                           <Themes>
                                               <WindowsSpotlight><%= WindowsSpotlight %></WindowsSpotlight>
                                               <UWPAppsUseLightTheme><%= UWPAppsUseLightTheme %></UWPAppsUseLightTheme>
                                               <SystemUsesLightTheme><%= SystemUsesLightTheme %></SystemUsesLightTheme>
                                               <DesktopBackground><%= txtDesktopBackground.Text %></DesktopBackground>
                                               <ThemeName><%= txtThemeName.Text %></ThemeName>
                                           </Themes>
                                           <ProductKey><%= txtProductKey.Text %></ProductKey>
                                           <OEMName><%= txtOEMName.Text %></OEMName>
                                           <TimeZone><%= txtTimeZone.Text %></TimeZone>
                                           <ComputerName><%= txtComputerName.Text %></ComputerName>
                                           <RegisteredOwner><%= txtRegisteredOwner.Text %></RegisteredOwner>
                                           <ConfigureChatAutoInstall><%= ConfigureChatAutoInstall %></ConfigureChatAutoInstall>
                                       </component>
                                   </settings>
                                   <settings pass="oobeSystem">
                                       <component name="Microsoft-Windows-Shell-Setup" processorArchitecture="arm64" publicKeyToken="31bf3856ad364e35" language="neutral" versionScope="nonSxS" xmlns:wcm="http://schemas.microsoft.com/WMIConfig/2002/State" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
                                           <OOBE>
                                               <HideEULAPage><%= HideEULAPage %></HideEULAPage>
                                               <HideLocalAccountScreen><%= HideLocalAccountScreen %></HideLocalAccountScreen>
                                               <HideOEMRegistrationScreen><%= HideOEMRegistrationScreen %></HideOEMRegistrationScreen>
                                               <HideOnlineAccountScreens><%= HideOnlineAccountScreens %></HideOnlineAccountScreens>
                                               <HideWirelessSetupInOOBE><%= HideWirelessSetupInOOBE %></HideWirelessSetupInOOBE>
                                               <OEMAppId><%= txtOEMAppId.Text %></OEMAppId>
                                               <UnattendEnableRetailDemo><%= UnattendEnableRetailDemo %></UnattendEnableRetailDemo>
                                               <SkipMachineOOBE><%= SkipMachineOOBE %></SkipMachineOOBE>
                                               <SkipUserOOBE><%= SkipUserOOBE %></SkipUserOOBE>
                                           </OOBE>
                                           <UserAccounts>
                                               <LocalAccounts>
                                                   <LocalAccount wcm:action="add">
                                                       <DisplayName><%= txtAdminDisplayName.Text %></DisplayName>
                                                       <Name><%= txtAdminName.Text %></Name>
                                                       <Group>Administrators</Group>
                                                       <Password>
                                                           <Value><%= txtAdminPassword.Text %></Value>
                                                           <PlainText>true</PlainText>
                                                       </Password>
                                                   </LocalAccount>
                                               </LocalAccounts>
                                           </UserAccounts>
                                           <AutoLogon>
                                               <Password>
                                                   <Value><%= txtAdminPassword.Text %></Value>
                                                   <PlainText>true</PlainText>
                                               </Password>
                                               <Enabled><%= AutoLogon_Enabled %></Enabled>
                                               <Username><%= txtAdminName.Text %></Username>
                                           </AutoLogon>
                                       </component>
                                   </settings>
                               </unattend>
                Else
                    document = <?xml version="1.0" encoding="UTF-8"?>
                               <unattend xmlns="urn:schemas-microsoft-com:unattend">
                                   <settings pass="specialize">
                                       <component name="Microsoft-Windows-International-Core" processorArchitecture="arm64" publicKeyToken="31bf3856ad364e35" language="neutral" versionScope="nonSxS" xmlns:wcm="http://schemas.microsoft.com/WMIConfig/2002/State" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
                                           <InputLocale><%= txtInputLocale.Text %></InputLocale>
                                           <SystemLocale><%= txtSystemLocale.Text %></SystemLocale>
                                           <UILanguage><%= txtUILanguage.Text %></UILanguage>
                                           <UILanguageFallback>en-US</UILanguageFallback>
                                           <UserLocale><%= txtUserLocale.Text %></UserLocale>
                                       </component>
                                       <component name="Microsoft-Windows-Shell-Setup" processorArchitecture="arm64" publicKeyToken="31bf3856ad364e35" language="neutral" versionScope="nonSxS" xmlns:wcm="http://schemas.microsoft.com/WMIConfig/2002/State" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
                                           <OEMInformation>
                                               <Logo><%= txtLogo.Text %></Logo>
                                               <Manufacturer><%= txtManufacturer.Text %></Manufacturer>
                                               <HelpCustomized><%= HelpCustomized %></HelpCustomized>
                                               <Model><%= txtModel.Text %></Model>
                                               <RecycleURL><%= txtRecycleURL.Text %></RecycleURL>
                                               <SupportAppURL><%= txtSupportAppURL.Text %></SupportAppURL>
                                               <SupportHours><%= txtSupportHours.Text %></SupportHours>
                                               <SupportPhone><%= txtSupportPhone.Text %></SupportPhone>
                                               <SupportProvider><%= txtSupportProvider.Text %></SupportProvider>
                                               <SupportURL><%= txtSupportURL.Text %></SupportURL>
                                               <TradeInURL><%= txtTradeInURL.Text %></TradeInURL>
                                           </OEMInformation>
                                           <Themes>
                                               <WindowsSpotlight><%= WindowsSpotlight %></WindowsSpotlight>
                                               <UWPAppsUseLightTheme><%= UWPAppsUseLightTheme %></UWPAppsUseLightTheme>
                                               <SystemUsesLightTheme><%= SystemUsesLightTheme %></SystemUsesLightTheme>
                                               <DesktopBackground><%= txtDesktopBackground.Text %></DesktopBackground>
                                               <ThemeName><%= txtThemeName.Text %></ThemeName>
                                           </Themes>
                                           <ProductKey><%= txtProductKey.Text %></ProductKey>
                                           <OEMName><%= txtOEMName.Text %></OEMName>
                                           <TimeZone><%= txtTimeZone.Text %></TimeZone>
                                           <ComputerName><%= txtComputerName.Text %></ComputerName>
                                           <RegisteredOwner><%= txtRegisteredOwner.Text %></RegisteredOwner>
                                           <ConfigureChatAutoInstall><%= ConfigureChatAutoInstall %></ConfigureChatAutoInstall>
                                       </component>
                                   </settings>
                                   <settings pass="oobeSystem">
                                       <component name="Microsoft-Windows-Shell-Setup" processorArchitecture="arm64" publicKeyToken="31bf3856ad364e35" language="neutral" versionScope="nonSxS" xmlns:wcm="http://schemas.microsoft.com/WMIConfig/2002/State" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
                                           <OOBE>
                                               <HideEULAPage><%= HideEULAPage %></HideEULAPage>
                                               <HideLocalAccountScreen><%= HideLocalAccountScreen %></HideLocalAccountScreen>
                                               <HideOEMRegistrationScreen><%= HideOEMRegistrationScreen %></HideOEMRegistrationScreen>
                                               <HideOnlineAccountScreens><%= HideOnlineAccountScreens %></HideOnlineAccountScreens>
                                               <HideWirelessSetupInOOBE><%= HideWirelessSetupInOOBE %></HideWirelessSetupInOOBE>
                                               <OEMAppId><%= txtOEMAppId.Text %></OEMAppId>
                                               <UnattendEnableRetailDemo><%= UnattendEnableRetailDemo %></UnattendEnableRetailDemo>
                                               <SkipMachineOOBE><%= SkipMachineOOBE %></SkipMachineOOBE>
                                               <SkipUserOOBE><%= SkipUserOOBE %></SkipUserOOBE>
                                           </OOBE>
                                       </component>
                                   </settings>
                               </unattend>
                End If
            End If
            document.Save(targetName, SaveOptions.None)
            MsgBox("Answer File saved at: " & targetName, MsgBoxStyle.Information, "Create Unattended Answer File")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Saving Answer File!")
        End Try
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If MsgBox("This program will create an unattend.xml file which you can place in {your_mount_directory}\Windows\Panther either for OEM or Consumer use. Click Yes to start the program. The unattend file you generate with this tool will only work on Arm64 PCs.", MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text) = DialogResult.Yes Then
            txtInputLocale.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Control Panel\International", "LocaleName", "")
            txtSystemLocale.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Control Panel\International", "LocaleName", "")
            txtUserLocale.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Control Panel\International", "LocaleName", "")
            txtRegisteredOwner.Text = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "RegisteredOwner", "")
            txtTimeZone.Text = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\TimeZoneInformation", "TimeZoneKeyName", "")
            txtComputerName.Text = My.Computer.Name
            txtManufacturer.Text = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "Manufacturer", "")
            txtModel.Text = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "Model", "")
            txtLogo.Text = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "Logo", "")
            txtSupportPhone.Text = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "SupportPhone", "")
            txtSupportHours.Text = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "SupportHours", "")
            txtSupportURL.Text = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "SupportURL", "")
            txtRecycleURL.Text = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "RecycleURL", "")
            txtTradeInURL.Text = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "TradeInURL", "")
            txtSupportAppURL.Text = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "SupportAppURL", "")
            If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "HelpCustomized", 0) = 1 Then
                chkHelpCustomized.Checked = True
            End If
        Else
            End
        End If
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            Process.Start("https://learn.microsoft.com/en-us/windows-hardware/manufacture/desktop/default-time-zones?view=windows-11")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Try
            Process.Start("https://learn.microsoft.com/en-us/windows-hardware/manufacture/desktop/available-language-packs-for-windows?view=windows-11")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chkSkipOOBE.CheckedChanged
        Select Case chkSkipOOBE.Checked
            Case True
                chkAutoLogon.Enabled = True
                txtAdminDisplayName.Enabled = True
                txtAdminName.Enabled = True
                txtAdminPassword.Enabled = True
            Case False
                chkAutoLogon.Enabled = False
                txtAdminDisplayName.Enabled = False
                txtAdminName.Enabled = False
                txtAdminPassword.Enabled = False
        End Select
    End Sub

    Private Sub CheckBox1_CheckedChanged_1(sender As Object, e As EventArgs) Handles chkRunCommands.CheckedChanged
        Select Case chkRunCommands.Checked
            Case True
                txtCommandDuringSpecializePhase.Enabled = True
                txtFirstLogonCommand.Enabled = True
                chkRequiresUserInput.Enabled = True
            Case False
                txtCommandDuringSpecializePhase.Enabled = False
                txtFirstLogonCommand.Enabled = False
                chkRequiresUserInput.Enabled = False
        End Select
    End Sub

    Private Sub TabPage6_Click(sender As Object, e As EventArgs) Handles TabPage6.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim opd As New SaveFileDialog
        opd.Filter = "XML Documents|*.xml"
        opd.DefaultExt = "xml"
        opd.FileName = "unattend.xml"
        opd.Title = "Create Unattended Answer File"
        If opd.ShowDialog() = DialogResult.OK Then
            CreateUnattend(opd.FileName)
        End If
    End Sub
End Class
