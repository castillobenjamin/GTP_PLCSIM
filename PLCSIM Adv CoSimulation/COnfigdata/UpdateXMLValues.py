import xml.etree.ElementTree as ET

tree = ET.parse("SimGlobalConfig_ALPEN.xml")
root = tree.getroot()

#Scan all children
for child in root:
    if child.tag == "Stoppers":
        for stopper_element in iter(child):
            for stopper_child in iter(stopper_element):
                if stopper_child.tag == "IsOpenSensor":
                    for stopper_grandchild in iter(stopper_child):
                        if stopper_grandchild.tag == "Value":
                            #print(stopper_grandchild.text)
                            stopper_grandchild.text = "false"
                            #print(stopper_grandchild.text)
                if stopper_child.tag == "IsClosedSensor":
                    for stopper_grandchild in iter(stopper_child):
                        if stopper_grandchild.tag == "Value":
                            #print(stopper_grandchild.text)
                            stopper_grandchild.text = "true"
                            #print(stopper_grandchild.text)

# Converting the xml data to byte object,
# for allowing flushing data to file
# stream
b_xml = ET.tostring(root)
 
# Opening a file under the name `items2.xml`,
# with operation mode `wb` (write + binary)
with open("UpdatedAlpenConfigFile.xml", "wb") as f:
    f.write(b_xml)

