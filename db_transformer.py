import sys
import logging

filename = sys.argv[0]
fh = open(filename, 'r')
count = 0
eof = False
file = ""
while count <= 18:
    fh.readline().strip('\n')
    count += 1


while eof == False:
    line = fh.readline().strip('\n')
    if line == '-- End of file':
        eof = True
    else:
        file += line + "\n"
        count += 1

fileWriter = open('prod_sqlscript.sql', 'w')
fileWriter.write(file)
