# �������� ��������� Python � ��������� ���������� DesignScript
import clr
clr.AddReference('ProtoGeometry')
from Autodesk.DesignScript.Geometry import *
clr.AddReference('RevitAPI')
from Autodesk.Revit.DB import *
clr.AddReference('RevitServices') 
import RevitServices
from RevitServices.Persistence import DocumentManager
from RevitServices.Transactions import TransactionManager
import itertools

doc = DocumentManager.Instance.CurrentDBDocument

# FILTER ELEMENTS
def get_fam(a):
	elements = FilteredElementCollector(doc).OfCategory(a).WhereElementIsNotElementType().ToElements()
	return elements	
	
# ADDED ALL TO COLLECTION
def write_par (a,b):
	error_list = []
	for element in a:
		try:
			name = element.LookupParameter(b).AsValueString()
			level = element.LookupParameter('���� �')
			if name:
				level.Set(name)

		except AttributeError:
			error_list.append(element)
		except:
			error_list.append(element)			
	return error_list

# ����� ������ ������� ����������� � ����� get_fam, ����� ��������� ������ �������� � list 
# 
parts = get_fam(BuiltInCategory.OST_Parts) #������� �������
stairs = get_fam(BuiltInCategory.OST_Stairs) #������� ������� 
struct_fram = get_fam(BuiltInCategory.OST_StructuralFraming) #������� ������� 
railing = get_fam(BuiltInCategory.OST_StairsRailing) #������� ������� 
roofs = get_fam(BuiltInCategory.OST_Roofs) #������� �������

walls = get_fam(BuiltInCategory.OST_Walls) #����������� �����
struct_col = get_fam(BuiltInCategory.OST_StructuralColumns) #����������� �����

floors = get_fam(BuiltInCategory.OST_Floors) #������� 
generic = get_fam(BuiltInCategory.OST_GenericModel) #������� 
windows = get_fam(BuiltInCategory.OST_Windows) #�������
doors = get_fam(BuiltInCategory.OST_Doors) #�������
foundation = get_fam(BuiltInCategory.OST_StructuralFoundation) #�������
rooms = get_fam(BuiltInCategory.OST_Rooms) #�������
furniture = get_fam(BuiltInCategory.OST_Furniture) #�������
equipment = get_fam(BuiltInCategory.OST_MechanicalEquipment) #�������
plumbingfixtures = get_fam(BuiltInCategory.OST_PlumbingFixtures) #�������
specialEquipment = get_fam(BuiltInCategory.OST_SpecialityEquipment) #�������

elements_base = list(itertools.chain(parts,stairs,railing,roofs,struct_fram))
elements_niz = list(itertools.chain(walls,struct_col))
elements_level = list(itertools.chain(floors,generic,windows,doors,foundation,rooms,furniture,equipment,plumbingfixtures,specialEquipment))

all = list(itertools.chain(elements_base,elements_niz,elements_level)) 

TransactionManager.Instance.EnsureInTransaction(doc)

base = write_par(elements_base,'������� �������')
niz = write_par(elements_niz,'����������� �����')
level = write_par(elements_level,'�������')

TransactionManager.Instance.TransactionTaskDone()


OUT = niz, level, base

#assemblies = get_fam(BuiltInCategory.OST_Assemblies)






