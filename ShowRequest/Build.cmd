docker build -f "d:\code\tt\002_web\showrequest\showrequest\dockerfile" --force-rm -t showrequest:latest  --label "com.microsoft.created-by=visual-studio" --label "com.microsoft.visual-studio.project-name=ShowRequest" "d:\code\tt\002_web\showrequest"

docker tag showrequest:latest a14907/showrequest:latest
docker push a14907/showrequest:latest