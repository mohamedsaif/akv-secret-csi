# Azure Key Vault Secret CSI Store

Reference implementation of Azure Key Vault secret store CSI driver

## Overview

Using Azure Key Vault secret store CSI driver on AKS requires planning and implementation details to optimize the use of it.

It is worth mentioning that AKV CSI driver support both Linux and Windows nodes which make it an appealing option for unified secret access across platforms.

Things to consider:

### Planning your key vault approach

There is no single right way to use Azure Key Vault to manage your secrets, but you give an idea of the approach, you might consider the following:

#### Central Key Vault

Used to store secrets that are managed by central team.

One example would be using it to store the TLS certificates that are issued and managed by central security team.

#### Project Key Vault

Used to store project specific secrets that are managed by the service/project team.

Examples may include service bus connection string, database credentials and other secrets that are directly connected to specific project and the responsibility for maintaining these secrets reside with the service/project team.

### Understand CSI specs

It is important to understand the different capaiblities and deployment options for the AKV CSI driver in order to maximize the utilization.

I would highly recommend to take your time reviewing the following documentations:

1. [AKV Secret Store CSI Driver Docs](https://azure.github.io/secrets-store-csi-driver-provider-azure/docs/)
2. [Secret Store CSI Driver Specs](https://secrets-store-csi-driver.sigs.k8s.io/introduction.html)

### Reference implementation application

I've created a sample ASP .NET web application to demonstrate accessing the secrets.

