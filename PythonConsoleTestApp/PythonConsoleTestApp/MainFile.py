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


def get_fam(a):
    elements = FilteredElementCollector(doc).OfCategory(a).WhereElementIsNotElementType().ToElements()
    return elements


def write_par(a, b):

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

all_enum_list = []
for i in BuiltInCategory:
    element = get_fam(i.value)
    all_enum_list.append(element)



# elements_base = list(itertools.chain(parts, stairs, railing, roofs, struct_fram))
# elements_niz = list(itertools.chain(walls, struct_col))
# elements_level = list(
#     itertools.chain(floors, generic, windows, doors, foundation, rooms, furniture, equipment, plumbingfixtures,
#                     specialEquipment))
#
# all = list(itertools.chain(all_enum_list))

TransactionManager.Instance.EnsureInTransaction(doc)

base = write_par(all_enum_list, 'Базовый уровень')
niz = write_par(all_enum_list, 'Зависимость снизу')
level = write_par(all_enum_list, 'Уровень')

TransactionManager.Instance.TransactionTaskDone()

OUT = niz, level, base

# assemblies = get_fam(BuiltInCategory.OST_Assemblies)