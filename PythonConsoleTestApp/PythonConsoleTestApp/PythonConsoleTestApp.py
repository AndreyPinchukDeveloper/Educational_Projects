# Включить поддержку Python и загрузить библиотеку DesignScript
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
			level = element.LookupParameter('Этаж №')
			if name:
				level.Set(name)

		except AttributeError:
			error_list.append(element)
		except:
			error_list.append(element)			
	return error_list

# можно каждый элемент подставлять в метод get_fam, потом добавлять каждый отдельно в list 
# 
parts = get_fam(BuiltInCategory.OST_Parts) #Базовый уровень
stairs = get_fam(BuiltInCategory.OST_Stairs) #Базовый уровень 
struct_fram = get_fam(BuiltInCategory.OST_StructuralFraming) #Базовый уровень 
railing = get_fam(BuiltInCategory.OST_StairsRailing) #Базовый уровень 
roofs = get_fam(BuiltInCategory.OST_Roofs) #Базовый уровень

walls = get_fam(BuiltInCategory.OST_Walls) #Зависимость снизу
struct_col = get_fam(BuiltInCategory.OST_StructuralColumns) #Зависимость снизу

floors = get_fam(BuiltInCategory.OST_Floors) #Уровень 
generic = get_fam(BuiltInCategory.OST_GenericModel) #Уровень 
windows = get_fam(BuiltInCategory.OST_Windows) #Уровень
doors = get_fam(BuiltInCategory.OST_Doors) #Уровень
foundation = get_fam(BuiltInCategory.OST_StructuralFoundation) #Уровень
rooms = get_fam(BuiltInCategory.OST_Rooms) #Уровень
furniture = get_fam(BuiltInCategory.OST_Furniture) #Уровень
equipment = get_fam(BuiltInCategory.OST_MechanicalEquipment) #Уровень
plumbingfixtures = get_fam(BuiltInCategory.OST_PlumbingFixtures) #Уровень
specialEquipment = get_fam(BuiltInCategory.OST_SpecialityEquipment) #Уровень

elements_base = list(itertools.chain(parts,stairs,railing,roofs,struct_fram))
elements_niz = list(itertools.chain(walls,struct_col))
elements_level = list(itertools.chain(floors,generic,windows,doors,foundation,rooms,furniture,equipment,plumbingfixtures,specialEquipment))

all = list(itertools.chain(elements_base,elements_niz,elements_level)) 

TransactionManager.Instance.EnsureInTransaction(doc)

base = write_par(elements_base,'Базовый уровень')
niz = write_par(elements_niz,'Зависимость снизу')
level = write_par(elements_level,'Уровень')

TransactionManager.Instance.TransactionTaskDone()


OUT = niz, level, base

#assemblies = get_fam(BuiltInCategory.OST_Assemblies)






