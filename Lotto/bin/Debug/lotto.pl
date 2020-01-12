% Author: Matej Lipovaèa
% Date: 10.1.2020.

generiraj_brojeve(0, []).
generiraj_brojeve(C, Ispis):-
                        C > 0,
                        C1 is C-1,
                        random(1, 35, U),
                        Ispis = [U|T],
                        generiraj_brojeve(C1, T).

findnum(X, []):-
           write("Promasen").

findnum(X,[X|Tail]):-
           write("Pogoden").

findnum(X,[Y|Tail]):-
           generiraj_brojeve(7, Tail).
           findnum(X, Tail).
           
test() :- write("Testghgtgtgt").