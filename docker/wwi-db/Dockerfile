FROM docker4dotnet/sql-server:2017-ltsc2019

ARG DB_BAK_URL="https://github.com/Microsoft/sql-server-samples/releases/download/wide-world-importers-v1.0/WideWorldImporters-Standard.bak"
RUN curl.exe -sSL -o /WideWorldImporters.bak $env:DB_BAK_URL

COPY *.ps1 /
RUN /restore-db.ps1

ENV sa_password="w1d3_W*rldd"