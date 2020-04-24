import sys
import logging

print('starting program')
filename = sys.argv[0]
fh = open(filename, 'r')
print('opened file' + filename)
count = 0
eof = False
file = ""
while count <= 18:
    line = fh.readline().strip('\n')
    print(line)
    count += 1


while eof == False:
    line = fh.readline().strip('\n')
    if line == '-- End of file':
        eof = True
    else:
        print(line)
        file += line + "\n"
        count += 1

fileWriter = open('prod_sqlscript.sql', 'w')
fileWriter.write(file)
print('finished')
