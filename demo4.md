# .NET Best Practices

## Demo 4: .NET Apps in Kubernetes

Deploy the apps using images on Docker Hub to Kubernetes running in Azure

### Pre-reqs

A Kubernetes cluster with Linux and Windows nodes. See [AKS](aks.md) for an example.

### Kubernetes manifests

- [Web API](kubernetes/wwi/api.yaml) - uses a Linux version of the image

- [Web API configuration](kubernetes/wwi/api-config-override.yaml) - JSON config settings

- [WCF app](kubernetes/wwi/svc.yaml) - uses the Windows image

- [WCF app configuration](kubernetes/wwi/svc-config-appsettings.yaml) - XML config settings

### Deploy

Check nodes:

```
kubectl get nodes -o wide
```

Deploy:

```
kubectl apply -f kubernetes/wwi/

kubectl get pods 

kubectl get ingress
```

### Test

- WCF Test client using http://ws.wwi.sixeyed.com

- Postman using http://api.wwi.sixeyed.com

Check logs:

```
kubectl logs -l app=wwi,component=api

kubectl logs -l app=wwi,component=svc
```