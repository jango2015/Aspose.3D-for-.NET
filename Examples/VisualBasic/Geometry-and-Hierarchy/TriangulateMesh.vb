﻿Imports Aspose.ThreeD
Imports Aspose.ThreeD.Entities
Imports Aspose.ThreeD.Utilities
Imports Aspose.ThreeD.Shading
Imports System.Drawing

Namespace Geometry_Hierarchy
    Class TriangulateMesh
        Public Shared Sub Run()
            ' ExStart:TriangulateMesh 
            ' The path to the documents directory.
            Dim MyDir As String = RunExamples.GetDataDir()
            ' Initialize scene object
            Dim scene As New Scene()
            scene.Open(MyDir & Convert.ToString("document.fbx"))
            scene.RootNode.Accept(AddressOf HandleMesh)

            MyDir = MyDir & RunExamples.GetOutputFilePath("document.fbx")
            scene.Save(MyDir, FileFormat.FBX7400ASCII)
            ' ExEnd:TriangulateMesh   
            Console.WriteLine(Convert.ToString(vbLf & "Mesh has been Triangulated." & vbLf & "File saved at ") & MyDir)
        End Sub

        Private Shared Function HandleMesh(node As Node)
            ' ExStart:HandleMesh
            Dim mesh As Mesh = node.GetEntity(Of Mesh)()
            If mesh IsNot Nothing Then
                ' Triangulate the mesh
                Dim newMesh As Mesh = PolygonModifier.Triangulate(mesh)
                ' Replace the old mesh
                node.Entity = mesh
            End If
            ' ExEnd:HandleMesh
            Return True

        End Function
    End Class
End Namespace