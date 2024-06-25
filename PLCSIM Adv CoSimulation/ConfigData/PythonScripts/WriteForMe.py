import xml.etree.cElementTree as ET

root = ET.Element("AlphaBotSystem")

#Bots
botList = ET.SubElement(root,"Bots")

#Modbus addresses for the bot IO
INITIAL_ADDR_OUT = 16
INITIAL_ADDR_IN = 301

#Used to keep track of how many bots have been counter
#4 bots per word (modbus address)
botCounter = 0
addrCounter = 0
offset = 4 #bit offset between each bot
#the bit position for each subelement
bit1 = 2
bit2 = 3
bit3 = 0
bit4 = 1

#output bot list
for i in range(1,151):
    if (botCounter == 4):
        addrCounter = addrCounter + 1
        botCounter = 0
    #Create a bot subelement
    botName = "Bot" + str(i)
    bot = ET.SubElement(botList, "Bot", name=botName)
    #Create the subelements of the bot element
    commFault = ET.SubElement(bot, "IsCommFaultToCell", type="output")
    estopStatus = ET.SubElement(bot, "EstopStatusToCell", type="output")
    estopCmd = ET.SubElement(bot, "EstopCmdFromCell", type="input")
    resetCmd = ET.SubElement(bot, "ResetCmdFromCell", type="input")
    #Create the subelements of each bot subelement
    for j,bit in [(commFault,bit1), (estopStatus,bit2), (estopCmd,bit3), (resetCmd,bit4)]:
        ET.SubElement(j, "Tag").text = "NoTag"
        ET.SubElement(j, "Address").text = str(INITIAL_ADDR_OUT + addrCounter)
        ET.SubElement(j, "BitPosition").text = str(bit + offset*botCounter)
        ET.SubElement(j, "Value").text = str(0)
    botCounter = botCounter + 1
tree = ET.ElementTree(root)
tree.write("filename.xml")