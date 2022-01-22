FROM mysql:5.7.22
EXPOSE 3306
COPY ./InqudePOC/db/migrations/ /home/database/
COPY ./InqudePOC/db/dataset/ /home/database/
COPY ./InqudePOC/ci/init_database.sh/ /docker-entrypoint-initdb.d/init_database.sh