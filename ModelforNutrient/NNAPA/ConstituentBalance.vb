Imports atcData
Imports atcData.atcDataGroup
Imports atcUtility
Imports MapWindow.Interfaces
Imports MapWinUtility

Imports Microsoft.VisualBasic
Imports System

Public Module ScriptStatTest
    Private Const pTestPath As String = "C:\Projects\20706-ABAG\Model\UCIs-mid-no-dep\NNAPA\"
    Private Const pScenario As String = "NNAPA" '"base"


    Public Sub ScriptMain(ByRef aMapWin As IMapWin)
        Logger.Dbg("Start")
        ChDriveDir(pTestPath)
        Logger.Dbg(" CurDir:" & CurDir())

        Dim lBalanceTypes As New atcCollection
        lBalanceTypes.Add("Water")
        lBalanceTypes.Add("SedimentCopper")

        Dim lOperations As New atcCollection
        lOperations.Add("P:", "PERLND")
        lOperations.Add("I:", "IMPLND")
        lOperations.Add("R:", "RCHRES")

        Dim lArgs As Object() = Nothing
        Dim lErr As String = ""
        Dim lDataManager As New atcDataManager(aMapWin) ' = Scripting.Run("vb", "", "subFindDataManager.vb", lErr, False, aMapWin, aMapWin)

        Dim lHspfBinFile As atcDataSource = New atcHspfBinOut.atcTimeseriesFileHspfBinOut
        Dim lHspfBinFileName As String = "nnapa.hbn"
        Dim lFileDetails As System.IO.FileInfo = New System.IO.FileInfo(lHspfBinFileName)

        Logger.Dbg(" AboutToOpen " & lHspfBinFileName)
        lDataManager.OpenDataSource(lHspfBinFile, lHspfBinFileName, Nothing)
        Logger.Dbg(" DataSetCount " & lHspfBinFile.DataSets.Count)

        Dim lLocations As new atcCollection '= lHspfBinFile.DataSets.AttributeValues("Location")
        lLocations.Add("I:101")
        lLocations.Add("P:101")
        lLocations.Add("P:102")
        lLocations.Add("P:103")
        lLocations.Add("P:104")
        lLocations.Add("P:105")
        lLocations.Add("R:1")
        'Logger.Dbg(" LocationCount " & lLocations.ToString(lLocations.Count))

        'Dim lConstituents As atcCollection = lHspfBinFile.DataSets.AttributeValues("Constituent")
        'Logger.Dbg(" ConstituentCount " & lConstituents.ToString(lConstituents.Count))

        For Each lBalanceType As String In lBalanceTypes
            Dim lConstituents2Output As New atcCollection
            Select Case lBalanceType
                Case "Water"
                    lConstituents2Output.Add("I:SUPY", "Rainfall")
                    lConstituents2Output.Add("I:SURO", "Runoff  ")
                    lConstituents2Output.Add("I:PET", "ET Potential")
                    lConstituents2Output.Add("I:IMPEV", "ET Actual")
                    lConstituents2Output.Add("P:SUPY", "Rainfall")
                    lConstituents2Output.Add("P:Header0", "Irrigation")
                    lConstituents2Output.Add("P:SURLI", "  Surface")
                    lConstituents2Output.Add("P:Header1", "Runoff")
                    lConstituents2Output.Add("P:SURO", "    Surface")
                    lConstituents2Output.Add("P:IFWO", "    Interflow")
                    lConstituents2Output.Add("P:AGWO", "    Baseflow")
                    lConstituents2Output.Add("P:PERO", "    Total")
                    lConstituents2Output.Add("P:IGWI", "Deep GW")
                    lConstituents2Output.Add("P:Header2", "Evaporation")
                    lConstituents2Output.Add("P:PET", "    Potential")
                    lConstituents2Output.Add("P:CEPE", "    Intercep St")
                    lConstituents2Output.Add("P:UZET", "    Upper Zone")
                    lConstituents2Output.Add("P:LZET", "    Lower Zone")
                    lConstituents2Output.Add("P:AGWET", "    Grnd Water")
                    lConstituents2Output.Add("P:BASET", "    Baseflow")
                    lConstituents2Output.Add("P:TAET", "    Total")
                Case "SedimentCopper"
                    lConstituents2Output.Add("I:SOSLD", "Solids   ")
                    lConstituents2Output.Add("I:SOQUAL-Copper", "Copper   ")
                    lConstituents2Output.Add("I:SOQS-Copper", "  Sed-Assoc Cu")
                    lConstituents2Output.Add("I:SOQO-Copper", "  Flow-Assoc Cu")
                    lConstituents2Output.Add("P:SOSED", "Sediment")
                    lConstituents2Output.Add("P:POQUAL-Copper", "Total Cu")
                    lConstituents2Output.Add("P:SOQS-Copper", "  Sed-Assoc Cu")
                    lConstituents2Output.Add("P:SOQO-Copper", "  Surf RO-Assoc Cu")
                    lConstituents2Output.Add("P:IOQUAL-Copper", "  Interflow Cu")
                    lConstituents2Output.Add("P:AOQUAL-Copper", "  Groundwater Cu")
                    lConstituents2Output.Add("R:ROVOL", "Outflow Total Water")
                    lConstituents2Output.Add("R:ISED-TOT", "Inflow Total Sediment")
                    lConstituents2Output.Add("R:DEPSCOUR-TOT", "Dep/Scour Total Sediment")
                    lConstituents2Output.Add("R:ROSED-TOT", "Outflow Total Sediment")
                    lConstituents2Output.Add("R:ISED-SAND", "Inflow Sand")
                    lConstituents2Output.Add("R:DEPSCOUR-SAND", "Dep/Scour Sand")
                    lConstituents2Output.Add("R:ROSED-SAND", "Outflow Sand")
                    lConstituents2Output.Add("R:ISED-SILT", "Inflow Silt")
                    lConstituents2Output.Add("R:DEPSCOUR-SILT", "Dep/Scour Silt")
                    lConstituents2Output.Add("R:ROSED-SILT", "Outflow Silt")
                    lConstituents2Output.Add("R:ISED-CLAY", "Inflow Clay")
                    lConstituents2Output.Add("R:DEPSCOUR-CLAY", "Dep/Scour Clay")
                    lConstituents2Output.Add("R:ROSED-CLAY", "Outflow Clay")
                    lConstituents2Output.Add("R:Copper-TROQAL", "Total Cu")
                    lConstituents2Output.Add("R:Copper-RODQAL", "  Dissolved Cu")
                    lConstituents2Output.Add("R:Copper-ROSQAL-Tot", "  Total Sed. Cu")
                    lConstituents2Output.Add("R:Copper-ROSQAL-SAND", "    Sand Cu")
                    lConstituents2Output.Add("R:Copper-ROSQAL-SILT", "    Silt Cu")
                    lConstituents2Output.Add("R:Copper-ROSQAL-CLAY", "    Clay Cu")
            End Select

            Dim lString As New Text.StringBuilder
            lString.AppendLine(lBalanceType & " Balance Report For " & pScenario)
            lString.AppendLine("   Run Made " & lFileDetails.CreationTime & vbCrLf)

            Dim lMatchConstituentGroup As atcDataGroup
            Dim lTempDataSet As atcDataSet

            For lOperationIndex As Integer = 0 To lOperations.Count - 1
                Dim lOperationKey As String = lOperations.Keys(lOperationIndex)
                For Each lLocation As String In lLocations
                    If lLocation.StartsWith(lOperationKey) Then
                        Logger.Dbg(lOperations(lOperationIndex) & " " & lLocation)
                        lString.AppendLine(lBalanceType & " Balance Report For " & lLocation)
                        Dim lTempDataGroup As atcDataGroup = lHspfBinFile.DataSets.FindData("Location", lLocation)
                        Logger.Dbg("     MatchingDatasetCount " & lTempDataGroup.Count)
                        Dim lNeedHeader As Boolean = True

                        For lIndex As Integer = 0 To lConstituents2Output.Count - 1
                            Dim lConstituentKey As String = lConstituents2Output.Keys(lIndex)
                            If lConstituentKey.StartsWith(lOperationKey) Then
                                lConstituentKey = lConstituentKey.Remove(0, 2)
                                Dim lConstituentName As String = lConstituents2Output(lIndex)
                                lMatchConstituentGroup = lTempDataGroup.FindData("Constituent", lConstituentKey)
                                If lMatchConstituentGroup.Count > 0 Then
                                    lTempDataSet = lMatchConstituentGroup.Item(0)
                                    Logger.Dbg("       Match " & lConstituentKey & " with " & lTempDataSet.ToString)

                                    Dim lSeasons As New atcSeasons.atcSeasonsCalendarYear
                                    Dim lSeasonalAttributes As New atcDataAttributes
                                    Dim lCalculatedAttributes As New atcDataAttributes
                                    lSeasonalAttributes.SetValue("Mean", 0)
                                    lSeasons.SetSeasonalAttributes(lTempDataSet, lSeasonalAttributes, lCalculatedAttributes)

                                    If lNeedHeader Then
                                        lString.Append("Date    " & vbTab & "Mean")
                                        For Each lAttribute As atcDefinedValue In lCalculatedAttributes
                                            lString.Append(vbTab & lAttribute.Arguments(1).Value)
                                        Next
                                        lString.AppendLine()
                                        lNeedHeader = False
                                    End If

                                    lString.Append(lConstituentName & vbTab & DF(lTempDataSet.Attributes.GetDefinedValue("SumAnnual").Value))
                                    For Each lAttribute As atcDefinedValue In lCalculatedAttributes
                                        lString.Append(vbTab & DF(lAttribute.Value))
                                    Next
                                    lString.AppendLine()
                                Else
                                    lString.AppendLine(vbCrLf & lConstituentName)
                                End If
                            End If
                        Next
                        lTempDataGroup = Nothing
                        lString.AppendLine(vbCrLf)
                    Else
                        'Logger.Dbg("   SKIP " & lLocation)
                    End If
                Next lLocation
            Next

            Dim lOutFileName As String = pScenario & "_" & lBalanceType & "_" & "Balance.txt"
            Logger.Dbg("  WriteReportTo " & lOutFileName)
            SaveFileString(lOutFileName, lString.ToString)
        Next lBalanceType
    End Sub

    Private Function DF(ByVal aValue As Double, Optional ByVal aDecimalPlaces As Integer = 3) As String
        Return DoubleToString(aValue, , , , 5)
        'Return Trim(Format(aValue, "##########0." & StrDup(aDecimalPlaces, "0")))
    End Function
End Module
