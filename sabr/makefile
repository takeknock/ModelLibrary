#CC = g++
OBJ = $(wildcard *.o) 
TESTOBJ = $(wildcard $(SRC)/*.o) 

#LNK = -lcppunit
#OUTFILENAME = a.out
#
#all:main $(OUTFILENAME) 
#
#main: $(OBJ)
#	$(CC) -o $(OBJ) -lcppunit 
#
#$(OUTFILENAME): *.cpp
#	$(CC) -o $@ $^ -lcppunit
#
#
#clean:
#	-rm $(OBJ) $(OUTFILENAME)
TESTDIR = src/TemplateTrainingTest
SRCDIR = src
CC = g++
impl = $(wildcard $(SRCDIR)/*.cpp)
testimpl = $(wildcard $(TESTDIR)/*.cpp)
LNK = -lcppunit
OUTFILENAME = a.out

$(OUTFILENAME): $(impl) $(testimpl)
	$(CC) $^ $(LNK)	

clean:
	-rm $(OUTFILENAME)

test:
	./$(OUTFILENAME)

