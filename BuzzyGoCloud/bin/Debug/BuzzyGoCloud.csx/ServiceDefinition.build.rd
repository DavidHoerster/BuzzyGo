<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="BuzzyGoCloud" generation="1" functional="0" release="0" Id="a4c54c36-51ad-4446-8e4c-355d8350dd4a" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="BuzzyGoCloudGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="BuzzyGo.Web:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/LB:BuzzyGo.Web:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="BuzzyGo.QueueMonitor:?IsSimulationEnvironment?" defaultValue="">
          <maps>
            <mapMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/MapBuzzyGo.QueueMonitor:?IsSimulationEnvironment?" />
          </maps>
        </aCS>
        <aCS name="BuzzyGo.QueueMonitor:?RoleHostDebugger?" defaultValue="">
          <maps>
            <mapMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/MapBuzzyGo.QueueMonitor:?RoleHostDebugger?" />
          </maps>
        </aCS>
        <aCS name="BuzzyGo.QueueMonitor:?StartupTaskDebugger?" defaultValue="">
          <maps>
            <mapMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/MapBuzzyGo.QueueMonitor:?StartupTaskDebugger?" />
          </maps>
        </aCS>
        <aCS name="BuzzyGo.QueueMonitor:BuzzyQuerySideConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/MapBuzzyGo.QueueMonitor:BuzzyQuerySideConnectionString" />
          </maps>
        </aCS>
        <aCS name="BuzzyGo.QueueMonitor:DataConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/MapBuzzyGo.QueueMonitor:DataConnectionString" />
          </maps>
        </aCS>
        <aCS name="BuzzyGo.QueueMonitor:DiagnosticsConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/MapBuzzyGo.QueueMonitor:DiagnosticsConnectionString" />
          </maps>
        </aCS>
        <aCS name="BuzzyGo.QueueMonitor:EventStoreConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/MapBuzzyGo.QueueMonitor:EventStoreConnectionString" />
          </maps>
        </aCS>
        <aCS name="BuzzyGo.QueueMonitor:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/MapBuzzyGo.QueueMonitor:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="BuzzyGo.QueueMonitorInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/MapBuzzyGo.QueueMonitorInstances" />
          </maps>
        </aCS>
        <aCS name="BuzzyGo.Web:?IsSimulationEnvironment?" defaultValue="">
          <maps>
            <mapMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/MapBuzzyGo.Web:?IsSimulationEnvironment?" />
          </maps>
        </aCS>
        <aCS name="BuzzyGo.Web:?RoleHostDebugger?" defaultValue="">
          <maps>
            <mapMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/MapBuzzyGo.Web:?RoleHostDebugger?" />
          </maps>
        </aCS>
        <aCS name="BuzzyGo.Web:?StartupTaskDebugger?" defaultValue="">
          <maps>
            <mapMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/MapBuzzyGo.Web:?StartupTaskDebugger?" />
          </maps>
        </aCS>
        <aCS name="BuzzyGo.Web:BuzzyQuerySideConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/MapBuzzyGo.Web:BuzzyQuerySideConnectionString" />
          </maps>
        </aCS>
        <aCS name="BuzzyGo.Web:DataConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/MapBuzzyGo.Web:DataConnectionString" />
          </maps>
        </aCS>
        <aCS name="BuzzyGo.Web:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/MapBuzzyGo.Web:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="BuzzyGo.WebInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/MapBuzzyGo.WebInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:BuzzyGo.Web:Endpoint1">
          <toPorts>
            <inPortMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/BuzzyGo.Web/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapBuzzyGo.QueueMonitor:?IsSimulationEnvironment?" kind="Identity">
          <setting>
            <aCSMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/BuzzyGo.QueueMonitor/?IsSimulationEnvironment?" />
          </setting>
        </map>
        <map name="MapBuzzyGo.QueueMonitor:?RoleHostDebugger?" kind="Identity">
          <setting>
            <aCSMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/BuzzyGo.QueueMonitor/?RoleHostDebugger?" />
          </setting>
        </map>
        <map name="MapBuzzyGo.QueueMonitor:?StartupTaskDebugger?" kind="Identity">
          <setting>
            <aCSMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/BuzzyGo.QueueMonitor/?StartupTaskDebugger?" />
          </setting>
        </map>
        <map name="MapBuzzyGo.QueueMonitor:BuzzyQuerySideConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/BuzzyGo.QueueMonitor/BuzzyQuerySideConnectionString" />
          </setting>
        </map>
        <map name="MapBuzzyGo.QueueMonitor:DataConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/BuzzyGo.QueueMonitor/DataConnectionString" />
          </setting>
        </map>
        <map name="MapBuzzyGo.QueueMonitor:DiagnosticsConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/BuzzyGo.QueueMonitor/DiagnosticsConnectionString" />
          </setting>
        </map>
        <map name="MapBuzzyGo.QueueMonitor:EventStoreConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/BuzzyGo.QueueMonitor/EventStoreConnectionString" />
          </setting>
        </map>
        <map name="MapBuzzyGo.QueueMonitor:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/BuzzyGo.QueueMonitor/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapBuzzyGo.QueueMonitorInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/BuzzyGo.QueueMonitorInstances" />
          </setting>
        </map>
        <map name="MapBuzzyGo.Web:?IsSimulationEnvironment?" kind="Identity">
          <setting>
            <aCSMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/BuzzyGo.Web/?IsSimulationEnvironment?" />
          </setting>
        </map>
        <map name="MapBuzzyGo.Web:?RoleHostDebugger?" kind="Identity">
          <setting>
            <aCSMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/BuzzyGo.Web/?RoleHostDebugger?" />
          </setting>
        </map>
        <map name="MapBuzzyGo.Web:?StartupTaskDebugger?" kind="Identity">
          <setting>
            <aCSMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/BuzzyGo.Web/?StartupTaskDebugger?" />
          </setting>
        </map>
        <map name="MapBuzzyGo.Web:BuzzyQuerySideConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/BuzzyGo.Web/BuzzyQuerySideConnectionString" />
          </setting>
        </map>
        <map name="MapBuzzyGo.Web:DataConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/BuzzyGo.Web/DataConnectionString" />
          </setting>
        </map>
        <map name="MapBuzzyGo.Web:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/BuzzyGo.Web/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapBuzzyGo.WebInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/BuzzyGo.WebInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="BuzzyGo.QueueMonitor" generation="1" functional="0" release="0" software="C:\Code4X\devLink\BuzzyGo\BuzzyGoCloud\bin\Debug\BuzzyGoCloud.csx\roles\BuzzyGo.QueueMonitor" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaWorkerHost.exe " memIndex="1792" hostingEnvironment="consoleroleadmin" hostingEnvironmentVersion="2">
            <settings>
              <aCS name="?IsSimulationEnvironment?" defaultValue="" />
              <aCS name="?RoleHostDebugger?" defaultValue="" />
              <aCS name="?StartupTaskDebugger?" defaultValue="" />
              <aCS name="BuzzyQuerySideConnectionString" defaultValue="" />
              <aCS name="DataConnectionString" defaultValue="" />
              <aCS name="DiagnosticsConnectionString" defaultValue="" />
              <aCS name="EventStoreConnectionString" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;BuzzyGo.QueueMonitor&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;BuzzyGo.QueueMonitor&quot; /&gt;&lt;r name=&quot;BuzzyGo.Web&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/BuzzyGo.QueueMonitorInstances" />
          </sCSPolicy>
        </groupHascomponents>
        <groupHascomponents>
          <role name="BuzzyGo.Web" generation="1" functional="0" release="0" software="C:\Code4X\devLink\BuzzyGo\BuzzyGoCloud\bin\Debug\BuzzyGoCloud.csx\roles\BuzzyGo.Web" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="?IsSimulationEnvironment?" defaultValue="" />
              <aCS name="?RoleHostDebugger?" defaultValue="" />
              <aCS name="?StartupTaskDebugger?" defaultValue="" />
              <aCS name="BuzzyQuerySideConnectionString" defaultValue="" />
              <aCS name="DataConnectionString" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;BuzzyGo.Web&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;BuzzyGo.QueueMonitor&quot; /&gt;&lt;r name=&quot;BuzzyGo.Web&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/BuzzyGo.WebInstances" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyID name="BuzzyGo.QueueMonitorInstances" defaultPolicy="[1,1,1]" />
        <sCSPolicyID name="BuzzyGo.WebInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="b24f0565-0c31-46a0-b2e3-d02ac7f9b1e6" ref="Microsoft.RedDog.Contract\ServiceContract\BuzzyGoCloudContract@ServiceDefinition.build">
      <interfacereferences>
        <interfaceReference Id="536c04ff-87f6-4133-97bb-c5a530f22a69" ref="Microsoft.RedDog.Contract\Interface\BuzzyGo.Web:Endpoint1@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/BuzzyGoCloud/BuzzyGoCloudGroup/BuzzyGo.Web:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>